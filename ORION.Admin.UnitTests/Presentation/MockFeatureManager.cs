

using ORION.DataAccess.Interfaces;

namespace ORION.Admin.UnitTests.Presentation
{
    public class MockFeatureManager : IFeatureManager
    {

        public bool Search { get; set; }
        public bool SearchByBirthBusinessProvince { get; set; }
        public bool PerformanceCounters { get; set; }
        public bool FeatureUsageLogging { get; set; }
        public bool CustomerSatisfaction { get; set; }
    }
}