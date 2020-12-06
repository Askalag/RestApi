using RestApi.Models;
using RestApi.Models.Cars;
using RestApi.Persistence.Repositories;

namespace RestApi.Persistence
{
    public interface IUnitOfWork
    {
        ICarRepository CarRepository { get; }
        IModelRepository ModelRepository { get; }
        
        public int Complete();
        public void Dispose();
    }
}