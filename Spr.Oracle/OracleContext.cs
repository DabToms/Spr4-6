using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Spr.Oracle.Models;

namespace Spr.Oracle;

public class OracleContext : DbContext
{
    public DbSet<CategoryRecord> Category { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("ORACLE_URI");
        if (connectionString == null)
        {
            Console.WriteLine("You must set your 'ORACLE_URI' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#set-your-connection-string");
            Console.WriteLine("Using Default connection string.");
            //Environment.Exit(0);
            connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=free)));User Id=system;Password=admin;";
        }

        optionsBuilder.UseOracle(connectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryRecord>().ToTable("Category");
        modelBuilder.Entity<CategoryRecord>().HasKey(e => e.Id);
        base.OnModelCreating(modelBuilder);
    }
}