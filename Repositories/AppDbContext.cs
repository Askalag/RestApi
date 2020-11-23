using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using RestApi.Models.Cars;

namespace RestApi.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        
        public DbSet<Car> Cars { get; set; }
        public DbSet<Inspection> Inspections { get; set; }

    }
}