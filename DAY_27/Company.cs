using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAY_27
{
    [Table("companies")]

    public class Company
    {
        [Key]

        public int Id { get; set; }
        [Column("name")]

        public String Name { get; set; }
        [Column("sphere")]

        public String Sphere { get; set; }
        [Column("country_id")]

        public int Country_id { get; set; }

        public Company() { }

        public Company(string name, string sphere, int country_id)
        {
            Name = name;
            Sphere = sphere;
            Country_id = country_id;
        }
    }
}
