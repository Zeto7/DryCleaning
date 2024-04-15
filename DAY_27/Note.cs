using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAY_27
{
    [Table("note")]

    public class Note
    {
        [Key]

        public int Id { get; set; }
        [Column("User_Id")]

        public int User_Id { get; set; }
        [Column("employee_id")]

        public int Employee_id { get; set; }
        [Column("company_id")]

        public int Company_id { get; set; }
        [Column("date")]

        public String Date { get; set; }

        public Note() { }

        public Note(int user_Id, int employee_id, int company_id, string date)
        {
            User_Id = user_Id;
            Employee_id = employee_id;
            Company_id = company_id;
            Date = date;
        }
    }
}
