using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAY_27.Tables
{
    [Table("contracts")]
    internal class Contract
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("client_id")]
        public int ClientId {  get; set; }
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Column("completion_date")]
        public DateTime? CompletionDate { get; set; }

        public Contract(int clientId, DateTime startDate, DateTime? completionDate)
        {
            ClientId = clientId;
            StartDate = startDate;
            CompletionDate = completionDate;
        }
    }
}
