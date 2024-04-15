﻿using System;
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
        [Key]
        public int Id { get; set; }
        [Column("client_id")]
        public int ClientId {  get; set; }
        [Column("start_date")]
        public string StartDate { get; set; }
        [Column("completion_date")]
        public string CompletionDate { get; set; }

        public Contract(int id, int clientId, string startDate, string completionDate)
        {
            Id = id;
            ClientId = clientId;
            StartDate = startDate;
            CompletionDate = completionDate;
        }
    }
}
