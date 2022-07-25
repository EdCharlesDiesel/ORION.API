using ORION.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORION.Admin.Models.Customers
{
    public class CustomerInfosViewModel
    {
        public int Id { get; set; }
        

        public string CompanyName { get; set; }


        public string ContactName { get; set; }


         public string ContactTitle { get;set;  }


        public string Address { get;set;  }


        public string City { get;set;  }


        public string Region { get;set;  }


        public string PostalCode { get; set; }


        public string Country { get;set;  }


        public string Phone { get; set; }


        public string Fax { get;set;  }

        //FIXME Fix tostring method
        // public override string ToString()
        // {
        //     return string.Format("{0}. {1} days in {2}, unit price: {3}",
        //         CustomerName, DurationInDays, CategoryName, UnitPrice);
        // }
    }
}
