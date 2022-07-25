using DDD.ApplicationLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COG.WEB.Queries
{
    public interface IDestinationListQuery: IQuery
    {
        Task<IEnumerable<SelectListItem>> AllDestinations();
    }
}
