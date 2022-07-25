using System;
using System.Collections.Generic;
using DDD.DomainLayer;

namespace ORION.Domain.Aggregates
{
    public interface IEmployee: IEntity<int>, IBaseEntity
    {
        void FullUpdate(IEmployee o);
       
        string LastName { get;}

       
        string FirstName { get;}

       
        string Title { get;}

      
        string TitleOfCourtesy { get;}


        DateTime? BirthDate { get;}

        
        DateTime? HireDate { get;}
       
        
        string Address { get;}

      
        string City { get;}

      
        string Region { get;}

      
        string PostalCode { get;}

       
        string Country { get;}

    
        string HomePhone { get;}

     
        string Extension { get;}


        byte[] Photo { get;}


        string Notes { get;}


        int? ReportsTo { get;}

      
        string PhotoPath { get;}

       // int EmployeeTerritoryId { get;}

      //  int OrderId { get;}

        // [ForeignKey("ReportsTo")]
        // public Employee Employee { get;}
       
        // public IEnumerable<IEmployee> Employees { get;}


        // public IEnumerable<IEmployeeTerritory> EmployeeTerritories { get;}
        

        // public IEnumerable<IOrder> Orders { get;}      
    }
}
