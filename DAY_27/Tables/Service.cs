using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAY_27.Tables
{
    [Table("services")]

    public class Service
    {
        [Key]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("type_id")]
        public int TypeId { get; set; }
        [Column("price")]
        public decimal Price { get; set; }

        public Service(int id, string name, int typeId, decimal price)
        {
            Id = id;
            Name = name;
            TypeId = typeId;
            Price = price;
        }
    }
}
