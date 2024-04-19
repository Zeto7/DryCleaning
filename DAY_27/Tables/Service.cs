using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAY_27.Tables
{
    [Table("services")]

    public class Service
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("type_id")]
        public int TypeId { get; set; }
        [Column("price")]
        public decimal Price { get; set; }

        public Service(string name, int typeId, decimal price)
        {
            Name = name;
            TypeId = typeId;
            Price = price;
        }

        public override string ToString() => Name;
    }
}
