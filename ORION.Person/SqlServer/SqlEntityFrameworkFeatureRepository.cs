
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.DomainLayer;
using Microsoft.EntityFrameworkCore;
using ORION.DataAccess.Contexts;
using ORION.DataAccess.Models;
using ORION.Domain.Aggregates;
using ORION.Domain.IRepositories;

namespace ORION.DataAccess.SqlServer
{
    public class SqlEntityFrameworkFeatureRepository :
            SqlEntityFrameworkCrudRepositoryBase<Feature, OrionDbContext>, IFeatureRepository
    {
        public SqlEntityFrameworkFeatureRepository(
            OrionDbContext context) : base(context)
        {

        }

        protected override DbSet<Feature> EntityDbSet => Context.Features;

        public Task<IFeature> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Feature> GetByUsername(string username)
        {
            return (
                from temp in EntityDbSet
                where (temp.Username == username || temp.Username == String.Empty)
                select temp
                ).ToList();
        }

        public IFeature New()
        {
            throw new NotImplementedException();
        }

        //TODO need to investigate

        // object IRepository<IFeature>.GetAll()
        // {
        //     throw new NotImplementedException();
        // }

        // object IRepository<IFeature>.GetById(int id)
        // {
        //     throw new NotImplementedException();
        // }

        IFeature IFeatureRepository.GetByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
