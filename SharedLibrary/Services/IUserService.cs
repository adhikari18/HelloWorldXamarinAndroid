using SharedLibrary.Models;
using System.Threading.Tasks;

namespace SharedLibrary.Services
{
    public interface IUserService
    {
        UserInfo[] GetUsers();
        int AddUser(UserInfo userInfo);
        bool ValidatePassword(string password);
    }
}
