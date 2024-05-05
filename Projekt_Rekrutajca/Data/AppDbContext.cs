using Microsoft.EntityFrameworkCore;
using Projekt_Rekrutajca.Models;

namespace Projekt_Rekrutajca.Data
{
    
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
            {

            }

            public DbSet<VehicleWriteDto> Vehicles { get; set; }
            public DbSet<City> Cities { get; set; } 
        }
    
}
