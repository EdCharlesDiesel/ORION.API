using DDD.ApplicationLayer;
using ORION.Domain.DTOs;

namespace ORION.Admin.Commands
{
    public class CreateProductCommand: ICommand
    {
        public CreateProductCommand(IProductFullEditDto values)
        {
            Values = values;
        }
        public IProductFullEditDto Values { get; private set; }
    }
}
