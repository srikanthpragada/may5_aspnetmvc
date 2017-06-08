using System.Data.Linq.Mapping;

namespace mvcdemo.Models
{
    [Table (Name ="categories")] 
    public  class Category
    {
        [Column ( Name ="catcode", IsPrimaryKey = true)]
        public string Code { get; set; }

        [Column(Name = "catdesc")]
        public string Description { get; set; }
    }
}
