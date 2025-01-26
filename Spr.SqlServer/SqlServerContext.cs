using Microsoft.EntityFrameworkCore;
using Spr.SqlServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.SqlServer;
public class SqlServerContext: DbContext
{
    public DbSet<CategoryRecord> Category { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("SQLSERVER_URI");
        if (connectionString == null)
        {
            Console.WriteLine("You must set your 'SQLSERVER_URI' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#set-your-connection-string");
            Console.WriteLine("Using Default connection string.");
            //Environment.Exit(0);
            connectionString = "Server=localhost;Initial Catalog=BazkiDanych;User ID=sa;Password=zse4%RDX;Encrypt=True;TrustServerCertificate=true;";
        }

        optionsBuilder.UseSqlServer(connectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryRecord>().ToTable("Category");
        modelBuilder.Entity<CategoryRecord>().HasKey(e => e.Id);
        base.OnModelCreating(modelBuilder);
    }
}
