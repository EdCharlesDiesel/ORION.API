using DDD.ApplicationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORION.Admin.Commands
{
    public class DeleteProductCommand: ICommand
    {
        public DeleteProductCommand(int id)
        {
            ProductId = id;
        }
        public int ProductId { get; private set; }
    }
}
