using System;
using System.Collections.Generic;
using ORION.DataAccess.Models;
using ORION.DataAccess.Services;

namespace ORION.Admin.UnitTests.Presentation
{
    public class MockBusinessOwnerService : IBusinessOwnerService
    {

        public MockBusinessOwnerService()
        {
            GetBusinessOwnersReturnValue = new List<BusinessOwner>();
        }

        public void DeleteBusinessOwnerById(int id)
        {
            throw new NotImplementedException();
        }

        public BusinessOwner GetBusinessOwnerByIdReturnValue { get; set; }
        public BusinessOwner GetBusinessOwnerById(int id)
        {
            return GetBusinessOwnerByIdReturnValue;
        }

        public IList<BusinessOwner> GetBusinessOwnersReturnValue { get; set; }

        public IList<BusinessOwner> GetBusinessOwners()
        {
            return GetBusinessOwnersReturnValue;
        }

        public BusinessOwner SaveBusinessOwnerArgumentValue { get; set; }
        public void Save(BusinessOwner saveThis)
        {
            SaveBusinessOwnerArgumentValue = saveThis;
        }

        public IList<BusinessOwner> SearchReturnValueForStateSearch { get; set; }

        public IList<BusinessOwner> Search(string firstName, string lastName, string birthState, string deathState)
        {
            return SearchReturnValueForStateSearch;
        }

        public IList<BusinessOwner> SearchReturnValue { get; set; }

        public IList<BusinessOwner> Search(string firstName, string lastName)
        {
            return SearchReturnValue;
        }
    }
}
