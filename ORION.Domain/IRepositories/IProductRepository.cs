using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface IProductRepository: IRepository<IProduct>
    {
        Task<IProduct> Get(int id);
        IProduct New();
        Task<IProduct> Delete(int id);
    }
}
