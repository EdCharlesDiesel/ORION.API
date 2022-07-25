using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ORION.DataAccess.Models;
using ORION.Map.Mapping.Abstract;

namespace ORION.Map.Mapping.Concrete
{
    public class ProductMap : BaseMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.ProductName).IsRequired(true);
            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.UnitPrice).IsRequired(true);
            builder.Property(x => x.Image).IsRequired(true);

            // builder.HasOne(x => x.Category)
            //  //   .WithMany(x => x.Products)
            //     .HasForeignKey(x => x.CategoryId);

            base.Configure(builder);
        }

    }
}
