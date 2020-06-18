using SharedLibrary.DataAccess;
using SharedLibrary.Models;
using System.Text.RegularExpressions;

namespace SharedLibrary.Services
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
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }
            var isAlphanumericContainingBoth = Regex.IsMatch(password, @"^(?=.*\d+)(?=.*[a-zA-Z])[0-9a-zA-Z]+$");
            var hasValidLength = password.Length >= 5 && password.Length <= 12;
            var consecutiveSubsequenceOfAtLeast2Chars = Regex.IsMatch(password, @"(..+)\1");

            //TODO: Get Clarification
            //I wasn't clear whether it needed subsequence of at least 1 char or 2 chars.
            //I assumed it would be invalid for 2+ characters if it follows itself.
            //Eg. it will consider AA1234 as valid but ABAB1234 as invalid;
            var isValid = isAlphanumericContainingBoth && hasValidLength && !consecutiveSubsequenceOfAtLeast2Chars;
            return isValid;
        }
    }
}
