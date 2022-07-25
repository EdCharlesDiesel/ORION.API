using DDD.ApplicationLayer;
using ORION.Domain.DTOs;

namespace ORION.Admin.Commands
{
    public class CreateProductCommand: ICommand
    {
        public CreateProductCommand(IProductFullEditDTO values)
        {
            Values = values;
        }
        public IProductFullEditDTO Values { get; private set; }
    }
}
