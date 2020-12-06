using RestApi.Models.Cars;

namespace RestApi.Persistence.Repositories
{
    public class ModelRepository : Repository<Model>, IModelRepository
    {
        public ModelRepository(AppDbContext context) : base(context)
        {
        }
    }
}