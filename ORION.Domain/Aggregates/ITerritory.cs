using System.Collections.Generic;
using DDD.DomainLayer;

namespace ORION.Domain.Aggregates
{
    public interface ITerritory : IEntity<int>, IBaseEntity
    {
        void FullUpdate(ITerritory o);

        string TerritoryDescription { get; }

        int RegionId { get; }

        //FIXME Need to investagate

        // IRegion Region { get; }

        // IEnumerable<IEmployeeTerritory> Employees { get; }

    }
}
