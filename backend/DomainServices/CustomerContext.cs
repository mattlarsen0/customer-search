using System.Collections.Generic;
using backend.DomainObjects;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace backend.DomainServices
{
    public class CustomerContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // initialize test db in the current directory
            var workingDir = Directory.GetCurrentDirectory();
            var dbPath = Path.Join(workingDir, "customer-test.db");

            options.UseSqlite($"Data Source={dbPath}");
        }
    }
}