using SQLite;

namespace SharedLibrary.Models
{
    [Table("Users")]
    public class UserInfo : BaseModel
    {
        public UserInfo() { }

        //TODO: Get details of max length rules
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }

        public UserInfo(string user, string password)
        {
            UserName = user;
            Password = password;
        }
    }
}
