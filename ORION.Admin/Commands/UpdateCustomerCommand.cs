using DDD.ApplicationLayer;
using ORION.Domain.DTOs;


namespace ORION.Admin.Commands
{
    public class UpdateCustomerCommand: ICommand
    {
        public UpdateCustomerCommand(ICustomerFullEditDTO updates)
        {
            Updates = updates;
        }
        public ICustomerFullEditDTO Updates { get; private set; }
    }
}
