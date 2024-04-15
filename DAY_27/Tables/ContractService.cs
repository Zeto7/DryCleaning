using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAY_27.Tables
{
    [Table("contract_services")]
    internal class ContractService
    {
        [Key]
        public int Id { get; set; }
        [Column("contract_id")]
        public int ContractId {get; set; }
        [Column("service_id")]
        public int ServiceId { get; set; }

        public ContractService(int id, int contractId, int serviceId)
        {
            Id = id;
            ContractId = contractId;
            ServiceId = serviceId;
        }
    }
}
