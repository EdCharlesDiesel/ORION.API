using DDD.DomainLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORION.DataAccess.SqlServer
{
    // public abstract class SqlEntityFrameworkCrudRepositoryBase<TEntity, TDbContext> :
    //     SqlEntityFrameworkRepositoryBase<TEntity, TDbContext>, IRepository<TEntity>
    //     where TEntity : class, IInt32Identity
    //     where TDbContext : DbContext

        public abstract class SqlEntityFrameworkCrudRepositoryBase<TEntity, TDbContext> :
        SqlEntityFrameworkRepositoryBase<TEntity, TDbContext>, IRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext

    {
        public SqlEntityFrameworkCrudRepositoryBase(
            TDbContext context) : base(context)
        {

        }

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        protected abstract DbSet<TEntity> EntityDbSet
        {
            get;
        }

        public virtual void Delete(TEntity deleteThis)
        {
            if (deleteThis == null)
                throw new ArgumentNullException("deleteThis", "deleteThis is null.");

            var entry = Context.Entry(deleteThis);

            if (entry.State == EntityState.Detached)
            {
                EntityDbSet.Attach(deleteThis);
            }

            EntityDbSet.Remove(deleteThis);

            Context.SaveChanges();
        }

        public virtual IList<TEntity> GetAll()
        {
            return EntityDbSet.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return (
                from temp in EntityDbSet
               // where temp.Id == id
                select temp
                ).FirstOrDefault();
        }

        public virtual void Save(TEntity saveThis)
        {
            if (saveThis == null)
                throw new ArgumentNullException("saveThis", "saveThis is null.");

            VerifyItemIsAddedOrAttachedToDbSet(
                EntityDbSet, saveThis);

            Context.SaveChanges();
        }

        // object IRepository<TEntity>.GetAll()
        // {
        //     throw new NotImplementedException();
        // }

        // object IRepository<TEntity>.GetById(int id)
        // {
        //     throw new NotImplementedException();
        // }
    }
}
