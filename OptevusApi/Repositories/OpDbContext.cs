using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using OptevusApi.Repositories.Models;

namespace OptevusApi.Repositories
{
    public class OpDbContext : DbContext
    {
        public DbSet<PolicyDetails> Policies { get; set; }
        public OpDbContext(string connectionstring) : base(GetOptions(connectionstring))
        {

        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PolicyDetails>().ToTable("policies");
        }
    }
}
