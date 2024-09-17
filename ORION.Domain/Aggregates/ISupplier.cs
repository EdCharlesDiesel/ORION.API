using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public interface ISupplier : IEntity<int>
    {
        void FullUpdate(ISupplier o);

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

        string HomePage { get; }

    }
}
