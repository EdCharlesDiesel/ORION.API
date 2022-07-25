using DDD.ApplicationLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ORION.Admin.Queries
{
    public interface ICategoryListQuery: IQuery
    {
        Task<IEnumerable<SelectListItem>> AllCategories();
    }
}
