using DDD.ApplicationLayer;
using ORION.Domain.DTOs;

namespace COG.WEB.Commands
{
    public class UpdateProductCommand: ICommand
    {
        public UpdateProductCommand(IProductFullEditDTO updates)
        {
            Updates = updates;
        }
        public IProductFullEditDTO Updates { get; private set; }
    }
}
