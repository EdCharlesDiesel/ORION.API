using DDD.ApplicationLayer;
using ORION.Domain.DTOs;

namespace ORION.Admin.Commands
{
    public class UpdateProductCommand: ICommand
    {
        public UpdateProductCommand(IProductFullEditDto updates)
        {
            Updates = updates;
        }
        public IProductFullEditDto Updates { get; private set; }
    }
}
