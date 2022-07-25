using System;
using System.Collections.Generic;
using ORION.DataAccess.Models;

namespace ORION.DataAccess.Services
{
    public interface IBusinessOwnerService
    {
        void Save(BusinessOwner saveThis);
        void DeleteBusinessOwnerById(int id);
        BusinessOwner GetBusinessOwnerById(int id);
        IList<BusinessOwner> GetBusinessOwners();
        IList<BusinessOwner> Search(
            string firstName, string lastName);
        IList<BusinessOwner> Search(string firstName,
            string lastName,
            string birthProvince,
            string businessProvince);
    }
}
