using ORION.Domain.Aggregates;
using ORION.Domain.IRepositories;
using System.Threading.Tasks;
using ORION.DataAccess.Models;
using ORION.Domain.Tools;

namespace ORION.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        //private OrionDbContext context;
        //public CategoryRepository(OrionDbContext context)
        //{
        //    this.context = context;
        //}
        //public IUnitOfWork UnitOfWork => context;

        //public async Task<ICategory> Get(int id)
        //{
        //    return await context.Categories.Where(m => m.Id == id)
        //        .FirstOrDefaultAsync();
        //}

        //public object GetAll()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public object GetById(int id)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public ICategory New()
        //{
        //    var model = new Category();
        //    context.Categories.Add(model);
        //    return model;
        //}
        public IUnitOfWork UnitOfWork { get; }
        public Task<ICategory> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICategory New()
        {
            throw new System.NotImplementedException();
        }
    }
}
