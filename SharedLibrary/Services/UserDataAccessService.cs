using SharedLibrary.Models;
using SharedLibrary.Repository;

namespace SharedLibrary.Services
{
    public class UserDataAccessService : IUserDataAccessService
    {
        private readonly IRepository<UserInfo> userRepo;

        public UserDataAccessService(string dbPath)
        {
            userRepo = new Repository<UserInfo>(dbPath);
        }
        public int AddUser(UserInfo userInfo)
        {
            return userRepo.Insert(userInfo);
        }

        public UserInfo[] GetUsers()
        {
            return userRepo.Get();
        }
    }
}
