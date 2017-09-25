using CreditApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CreditApp.Infrastructure
{
    public class CreditDbContext : DbContext
    {
        public CreditDbContext() { }

        public CreditDbContext(DbContextOptions<CreditDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Ledger> Ledgers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<LedgerRecord> LedgerRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\jdoss\\Source\\Repos\\SimpleCreditApp\\SimpleCreditApp\\src\\CreditApp.Api\\data\\credit-app.db");
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{

        //}
    }
}
