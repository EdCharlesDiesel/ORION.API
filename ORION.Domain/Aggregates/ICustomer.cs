using System.Collections.Generic;
using DDD.DomainLayer;

namespace ORION.Domain.Aggregates
{
    public interface ICustomer : IEntity<int>, IBaseEntity
    {
        void FullUpdate(ICustomer o);

        string CompanyName { get; }


        string ContactName { get; }


        string ContactTitle { get; }


        string Address { get; }


        string City { get; }


        string Region { get; }


        string PostalCode { get; }


        string Country { get; }


        string Phone { get; }


        string Fax { get; }
        
        // TODO Investigate
        // IEnumerable<CustomerCustomerDemo> CustomerDemographics { get; }


        // IEnumerable<Order> Orders { get; }
    }
}
