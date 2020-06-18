using SQLite;

namespace SharedLibrary
{
    [Table("Users")]
    public class UserInfo
    {
        public UserInfo() { }

        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        [MaxLength(50)]
        public string User { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }

        public UserInfo(string user, string password)
        {
            User = user;
            Password = password;
        }
    }
}
