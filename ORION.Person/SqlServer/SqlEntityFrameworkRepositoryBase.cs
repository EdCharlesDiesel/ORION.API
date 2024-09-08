using Microsoft.EntityFrameworkCore;

namespace ORION.Person.SqlServer
{
    public abstract class SqlEntityFrameworkRepositoryBase<TEntity, TDbContext> :
        IDisposable where TEntity : class
        where TDbContext : DbContext
    {
        protected SqlEntityFrameworkRepositoryBase(
            TDbContext context)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context), "context is null.");
        }

        public void Dispose()
        {
            ((IDisposable)_Context).Dispose();
        }

        private TDbContext _Context;

        protected TDbContext Context
        {
            get
            {
                return _Context;
            }
        }

        protected void VerifyItemIsAddedOrAttachedToDbSet(DbSet<TEntity> dbset, TEntity? item)
        {
            if (item == null)
            {
                return;
            }
            else
            {
                // if (item.Id == 0)
                // {
                //     dbset.Add(item);
                // }
                // else
                // {
                    var entry = _Context.Entry<TEntity>(item);

                    if (entry.State == EntityState.Detached)
                    {
                        dbset.Attach(item);
                    }

                    entry.State = EntityState.Modified;
              //  }
            }
        }
    }
}
