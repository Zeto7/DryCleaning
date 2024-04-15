using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAY_27.Tables
{
    [Table("types")]

    public class ServiceType
    {
        [Key]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public ServiceType(int id,string name)
        {
            Id = id;
            Name = name;
        }
    }
}
