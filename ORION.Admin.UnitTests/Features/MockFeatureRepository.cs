using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.DomainLayer;
using ORION.DataAccess.Models;
using ORION.Domain.Aggregates;
using ORION.Domain.IRepositories;

namespace ORION.Admin.UnitTests.Features
{
    public class MockFeatureRepository : IFeatureRepository
    {

        public MockFeatureRepository()
        {
            GetByUsernameReturnValue = new List<Feature>();
        }

        public void Delete(Feature deleteThis)
        {
            throw new NotImplementedException();
        }

        public IList<Feature> GetAll()
        {
            throw new NotImplementedException();
        }

        public Feature GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Feature> GetByUsernameReturnValue
        {
            get;
            set;
        }

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public IList<Feature> GetByUsername(string username)
        {
            return GetByUsernameReturnValue;
        }

        public void Save(Feature saveThis)
        {
            throw new NotImplementedException();
        }

        IFeature IFeatureRepository.GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IFeature> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IFeature New()
        {
            throw new NotImplementedException();
        }
    }
}
