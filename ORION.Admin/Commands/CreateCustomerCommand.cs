using DDD.ApplicationLayer;
using ORION.Domain.DTOs;

namespace ORION.Admin.Commands
{
    public class CreateCustomerCommand: ICommand
    {
        public CreateCustomerCommand(ICustomerFullEditDTO values)
        {
            Values = values;
        }
        public ICustomerFullEditDTO Values { get; private set; }
    }
}
