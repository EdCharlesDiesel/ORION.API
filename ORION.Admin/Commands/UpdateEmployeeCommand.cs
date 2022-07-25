using DDD.ApplicationLayer;
using ORION.Domain.DTOs;

namespace ORION.Admin.Commands
{
    public class UpdateEmployeeCommand: ICommand
    {
        public UpdateEmployeeCommand(IEmployeeFullEditDTO updates)
        {
            Updates = updates;
        }
        public IEmployeeFullEditDTO Updates { get; private set; }
    }
}
