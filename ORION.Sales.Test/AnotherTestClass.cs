﻿using Xunit;

namespace ORION.HumanResources.Test
{
    [Collection("No parallelism")]
    public class AnotherTestClass
    {
        [Fact]
        public void SlowTest2()
        {
            Thread.Sleep(5000);
            Assert.True(true);
        }
    }
}
