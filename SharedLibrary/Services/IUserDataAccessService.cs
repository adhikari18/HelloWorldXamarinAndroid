using SharedLibrary.Models;
using System.Threading.Tasks;

namespace SharedLibrary.Services
{
    public interface IUserDataAccessService
    {
        UserInfo[] GetUsers();
        int AddUser(UserInfo userInfo);
    }
}
