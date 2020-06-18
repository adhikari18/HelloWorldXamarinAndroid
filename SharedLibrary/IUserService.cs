using System.Threading.Tasks;

namespace SharedLibrary
{
    public interface IUserService
    {
        UserInfo[] GetUsers();
        int AddUser(UserInfo userInfo);
        bool ValidatePassword(string password);
    }
}
