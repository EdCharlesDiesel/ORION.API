using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ORION.DataAccess.Models;
using ORION.Map.Mapping.Abstract;

namespace ORION.Map.Mapping.Concrete
{
    public class CategoryMap : BaseMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
         //   builder.HasKey(x => x.Id);
          //  builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            base.Configure(builder);
        }
    }
}
