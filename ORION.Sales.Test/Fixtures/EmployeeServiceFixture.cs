﻿using ORION.Sales.Test.Services;

namespace ORION.Sales.Test.Fixtures
{
    public class EmployeeServiceFixture : IDisposable
    {
        //public IEmployeeManagementRepository EmployeeManagementTestDataRepository
        //    { get; }
        //public EmployeeService EmployeeService 
        //    { get; }

        //public EmployeeServiceFixture()
        //{
        //    EmployeeManagementTestDataRepository =
        //        new EmployeeManagementTestDataRepository();
        //    EmployeeService = new EmployeeService(
        //        EmployeeManagementTestDataRepository,
        //        new EmployeeFactory());
        //}

        public void Dispose()
        {
            // clean up the setup code, if required
        }
    }
}
