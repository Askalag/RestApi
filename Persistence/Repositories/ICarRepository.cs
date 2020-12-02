using RestApi.Models.Cars;
using RestApi.Persistence.Repositories;

namespace RestApi.Persistence.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        
    }
}