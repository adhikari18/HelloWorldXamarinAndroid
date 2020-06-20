using SQLite;

namespace SharedLibrary.Models
{
    [Table("Users")]
    public class UserInfo : BaseModel
    {
        public UserInfo() { }
                
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserInfo(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
