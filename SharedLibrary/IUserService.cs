using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public interface IUserService
    {
        Task<UserInfo[]> GetUsersAsync();
        Task<int> AddUserAsync(UserInfo userInfo);
        Task<bool> ValidatePassword(string password);
    }
}
