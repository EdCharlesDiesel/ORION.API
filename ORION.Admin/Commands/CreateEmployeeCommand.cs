using DDD.ApplicationLayer;
using ORION.Domain.DTOs;

namespace ORION.Admin.Commands
{
    public class CreateEmployeeCommand: ICommand
    {
        public CreateEmployeeCommand(IEmployeeFullEditDTO values)
        {
            Values = values;
        }
        public IEmployeeFullEditDTO Values { get; private set; }
    }
}
