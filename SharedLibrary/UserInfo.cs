using System;

namespace SharedLibrary
{
    public class UserInfo
    {
        public string User { get; set; }
        public string Password { get; set; }

        public UserInfo(string user, string password)
        {
            User = user;
            Password = password;
        }
    }
}
