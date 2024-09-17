using System;

namespace ORION.Domain.DTOs
{
    public interface ICustomerFullEditDto
    {
        int Id { get; set; }

        string CompanyName { get; set;}


        string ContactName { get;set; }


        string ContactTitle { get; set;}


        string Address { get; set;}


        string City { get;set; }


        string Region { get;set; }


        string PostalCode { get;set; }


        string Country { get; set;}


        string Phone { get; set;}


        string Fax { get;set; }
    }
}