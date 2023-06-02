using FirstAPIdotnet7.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace FirstAPIdotnet7.Infra
{
    public class ConnectionContext : DbContext
    {
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS1;Database=Managerdotnetseven;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Company> Companies { get; set; }

    }
}
