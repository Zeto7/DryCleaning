using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAY_27.Tables
{
    [Table("clients")]

    public class Client    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }
        [Column("Surname")]
        public string Surname { get; set; }
        [Column("fathername")]
        public string Fathername { get; set; }
        [Column("phone")]
        public string Phone {  get; set; }
        [Column("address")]
        public string Adress { get; set; }
        public Client(string name, string surname, string fathername, string adress, string phone)
        {
            Name = name;
            Surname = surname;
            Fathername = fathername;
            Adress = adress;
            Phone = phone;
        }

        public override string ToString() => $"{Name} {Surname} {Fathername}";
    }
}
