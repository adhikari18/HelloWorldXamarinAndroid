using SharedLibrary.Models;
using SharedLibrary.Repository;

namespace SharedLibrary.Services
{
    public class UserDataAccessService : IUserDataAccessService
    {
        private readonly IRepository<UserInfo> _userRepo;

        public UserDataAccessService(string dbPath)
        {
            _userRepo = new Repository<UserInfo>(dbPath);
        }
        public int AddUser(UserInfo userInfo)
        {
            return _userRepo.Insert(userInfo);
        }

        public UserInfo[] GetUsers()
        {
            return _userRepo.Get();
        }
    }
}
