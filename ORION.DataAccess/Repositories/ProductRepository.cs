using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.IRepositories;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ORION.DataAccess.Models;
using ORION.Domain.Events;
using ORION.DataAccess.Contexts;

namespace ORION.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private OrionDbContext context;
        public ProductRepository(OrionDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public async Task<IProduct> Get(int id)
        {
            return await context.Products.Where(m => m.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IProduct> Delete(int id)
        {
            var model = await Get(id);
            if (model == null) return null;
            context.Products.Remove(model as Product);
            model.AddDomainEvent(
                new ProductDeleteEvent(
                    model.Id, (model as Product).EntityVersion));
            return model;
        }
        
        public IProduct New()
        {
            var model = new Product() {EntityVersion=1 };
            context.Products.Add(model);
            return model;
        }

        // public async Task<bool> UploadFile(MultipartReader reader,MultipartSection? section)
        // {
        //     while (section != null)
        //     {
        //         var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(
        //          section.ContentDisposition, out var contentDisposition
        //         );

        //         if (hasContentDispositionHeader)
        //         {
        //             if (contentDisposition.DispositionType.Equals("form-data") &&
        //             (!string.IsNullOrEmpty(contentDisposition.FileName.Value) ||
        //             !string.IsNullOrEmpty(contentDisposition.FileNameStar.Value)))
        //             {
        //                 string filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
        //                 byte[] fileArray;
        //                 using (var memoryStream = new MemoryStream())
        //                 {
        //                     await section.Body.CopyToAsync(memoryStream);
        //                     fileArray = memoryStream.ToArray();
        //                 }
        //                 using (var fileStream = System.IO.File.Create(Path.Combine(filePath, contentDisposition.FileName.Value)))
        //                 {
        //                     await fileStream.WriteAsync(fileArray);
        //                 }
        //             }
        //         }
        //         section = await reader.ReadNextSectionAsync();
        //     }
        //     return true;
        // }
    }
}
