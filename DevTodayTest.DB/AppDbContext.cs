using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTodayTest.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<CabData> CabData { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESK\\SQLEXPRESS;Database=Test;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
