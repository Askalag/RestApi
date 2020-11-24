using RestApi.Models;
using RestApi.Models.Cars;

namespace RestApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private BaseRepository<Car> _cars;
        private BaseRepository<Inspection> _inspections;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IRepository<Car> Cars
        {
            get
            {
                return _cars ??= new BaseRepository<Car>(_context);
            }
        }
        
        public IRepository<Inspection> Inspections
        {
            get
            {
                return _inspections ??= new BaseRepository<Inspection>(_context);
            }
        }
        
        //todo
        public IRepository<Car> Customers { get; }
        public IRepository<Inspection> Orders { get; }
        public void Commit()
        {
            throw new System.NotImplementedException();
        }
    }
}