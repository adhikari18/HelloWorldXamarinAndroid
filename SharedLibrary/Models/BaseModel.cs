using SQLite;

namespace SharedLibrary.Models
{
    public class BaseModel
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
    }
}
