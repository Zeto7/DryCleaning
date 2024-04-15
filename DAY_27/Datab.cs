using DAY_27.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAY_27
{
    internal class Datab : DbContext
    {
        string connect = @"Data Source=.\SQL_SERVER;Trust Server Certificate=True;persist security info=True;Integrated Security=SSPI;AttachDbFilename=D:\Anal.mdf";

        public DbSet<Client> Clients { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<ServiceType> Types { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractService> ContractServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connect);
        }
    }
}
