using Microsoft.EntityFrameworkCore;
using RestApi.Models.Cars;
using RestApi.Persistence.Repositories;

namespace RestApi.Persistence.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(AppDbContext context) : base(context)
        {
        }
    }
}