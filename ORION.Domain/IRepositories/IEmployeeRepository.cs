﻿using ORION.Domain.Aggregates;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface IEmployeeRepository:IRepository<IEmployee>
    {
        Task<IEmployee> Get(int id);
        IEmployee New();
    }
}
