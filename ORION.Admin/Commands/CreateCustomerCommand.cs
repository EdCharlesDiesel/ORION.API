using DDD.ApplicationLayer;
using ORION.Domain.DTOs;

namespace ORION.Admin.Commands
{
    public class CreateCustomerCommand: ICommand
    {
        public CreateCustomerCommand(ICustomerFullEditDto values)
        {
            Values = values;
        }
        public ICustomerFullEditDto Values { get; private set; }
    }
}
