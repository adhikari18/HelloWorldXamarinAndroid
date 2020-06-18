using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class UserService : IUserService
    {
        IRepository<UserInfo> _userRepository;
        public UserService(string dbPath)
        {
            var connection = new SQLiteAsyncConnection(dbPath);
            _userRepository = new Repository<UserInfo>(connection);

        }
        public async Task<int> AddUserAsync(UserInfo userInfo)
        {
            var result = await _userRepository.Insert(userInfo);
            return result;
        }

        public async Task<UserInfo[]> GetUsersAsync()
        {
            var users = await _userRepository.Get();
            return users.ToArray();
        }

        public Task<bool> ValidatePassword(string password)
        {
            var isAlphanumeric = Regex.IsMatch(password, @"^([a-zA-Z]+[0-9]|[0-9]+[a-zA-Z])[A-Za-z0-9]*$");
            var hasValidLength = password.Length >= 5 && password.Length <= 12;
            var consecutiveSubsequenceOfAtLeast1Char = Regex.IsMatch(password, @".*(.+)\1.*");
            //I wasnt clear whether it needed subsequence of at least 1 char or 2 chars. The above will match AA1234 and will be considered invalid;
            //var consecutiveSubsequenceOfAtLeast2Char = Regex.IsMatch(password, @".*([a-zA-Z0-9]{2})\1.*");
            var result = isAlphanumeric && hasValidLength && !consecutiveSubsequenceOfAtLeast1Char; // eg. This will consider ABAB12 as invalid.
            return Task.FromResult(result);
        }
    }
}
