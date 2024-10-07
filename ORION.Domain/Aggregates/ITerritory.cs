using System.Collections.Generic;
using ORION.Domain.Tools;

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
