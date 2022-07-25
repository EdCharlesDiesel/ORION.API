using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ORION.DataAccess.Contexts;

namespace ORION.Admin.Queries
{
    public class CategoryListQuery : ICategoryListQuery
    {
        OrionDbContext context;
        public CategoryListQuery(OrionDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<SelectListItem>> AllCategories()
        {
            return (await context.Categories.Select(m => new
            {
                Text = m.CategoryName,
                Value = m.Id
            })
            .OrderBy(m => m.Text)
            .ToListAsync())
            .Select(m => new SelectListItem
            {
                Text = m.Text,
                Value = m.Value.ToString()
            });
        }
    }
}
