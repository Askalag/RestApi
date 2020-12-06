using RestApi.Persistence.Repositories;

namespace RestApi.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ICarRepository CarRepository { get; private set; }
        public IModelRepository ModelRepository { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            CarRepository = new CarRepository(_context);
            ModelRepository = new ModelRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}