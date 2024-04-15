using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAY_27.Tables
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        public int Id {  get; set; }
        [Column("login")]
        public string Login { get; set; }
        [Column("password")]
        public string Password { get; set; }

        public Employee(string login, string password) 
        {
            Login = login;
            Password = password;
        }
    }
}
