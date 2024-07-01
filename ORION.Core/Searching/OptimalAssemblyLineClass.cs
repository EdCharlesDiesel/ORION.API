namespace OptimalAssemblyLine
{
    /// <summary>
    /// One of the most efficent ways to run a factory is to use an assemby line,
    /// with multiple stations performming different assembling steps simutaniously 
    /// in order to save time. But an assembly line is only as fast as its slowest 
    /// sation/step: for example, if an assembly line has 100 ifferent steps 
    /// performed by a 100 different station, with 99 steps taking 1 minute each
    /// to complete and 1 step is taking 1 hour to complete, the the entire assembly
    /// line is dramatically slowed down by the 1 hour-long step.
    /// 
    /// Write a function that takes in a non-empty array of positive integers
    /// stepDurations and a positive integer numStations. The input the array of 
    /// integer represents the times the various steps in an assembly process 
    /// take, and the input integer represents the number of station can perform
    /// multiple steps, so long as these steps whose times appear consecitively in the
    /// stepDurations array. Your function should return the longest duration of
    /// a single station in the assembly line after optimizaing the assembly line
    /// (i.e, minimizing its slowest station/steps).
    /// 
    /// You can assume that there will never be more stations than steps.
    /// 
    /// </summary>
    public class OptimalAssemblyLineClass
    {
        public int OptimalAssemblyLine(int[] stepDurations, int numStations)
        {
            int left = Int32.MinValue;
            int right = 0;
            int maxStationDuration = Int32.MaxValue;

            foreach (int stepDuration in stepDurations) 
            {
                //left= Math.Max(left, stepDuration);
                //right +=
            }

            return left;
        }
    }
}