using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using RestApi.Models.Cars;

namespace RestApi.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Inspection> Inspections { get; set; }

    }
}