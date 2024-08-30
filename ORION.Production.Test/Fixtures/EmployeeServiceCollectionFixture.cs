﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ORION.HumanResources.Test.Fixtures
{
    [CollectionDefinition("EmployeeServiceCollection")]
    public class EmployeeServiceCollectionFixture 
        : ICollectionFixture<EmployeeServiceFixture>
    {
    }
}
