using SQLite;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class UserService : IUserService
    {
        public int AddUser(UserInfo userInfo)
        {
            return DatabaseHelper.AddUser(userInfo);
        }

        public UserInfo[] GetUsers()
        {
            return DatabaseHelper.GetUsers();
        }

        public bool ValidatePassword(string password)
        {
            var isAlphanumericContainingBoth = Regex.IsMatch(password, @"^([a-zA-Z]+[0-9]|[0-9]+[a-zA-Z])[A-Za-z0-9]*$");
            var hasValidLength = password.Length >= 5 && password.Length <= 12;
            var consecutiveSubsequenceOfAtLeast1Char = Regex.IsMatch(password, @".*(.+)\1.*");
            //I wasnt clear whether it needed subsequence of at least 1 char or 2 chars.
            //I assumed it would be invalid even for 1 character if it follows itself.
            //Eg. it will consider AA1234 as invalid;
            var isValid = isAlphanumericContainingBoth && hasValidLength && !consecutiveSubsequenceOfAtLeast1Char; 
            return isValid;
        }
    }
}
