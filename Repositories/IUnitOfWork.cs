using RestApi.Models;
using RestApi.Models.Cars;

namespace RestApi.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Car> Customers { get; }
        IRepository<Inspection> Orders { get; }
        void Commit();
    }
}