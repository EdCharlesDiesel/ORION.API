namespace MergeOverlappingIntervals
{
    /// <summary>
    /// Write a function that takes in a non-empty array of arbtitary
    /// intervals, merges any overlapping intevals, and returns the new
    /// intervals in no particular order.
    /// 
    /// 
    /// </summary>
    public class MergeOverlappingIntervalsClass
    {
        public int[][] MergeOverlappingIntervals(int[][] intervals)
        {
            int[][] sortedIntervals = intervals.Clone() as int[][];
            Array.Sort(sortedIntervals,(a,b)=> a[0].CompareTo(b[0]));

            List<int[]> mergedIntervals = new List<int[]>();
            int[] currentIntevaal = sortedIntervals[0];
            mergedIntervals.Add(currentIntevaal);

            foreach (var nextInterval in sortedIntervals)
            {
                int currentIntervalEnd = currentIntevaal[1];
                int nextIntervalStart = nextInterval[0];
                int nextIntervalEnd = nextInterval[1];

                if (currentIntervalEnd >= nextIntervalStart)
                {
                    currentIntevaal[1] = Math.Max(currentIntervalEnd, nextIntervalEnd);
                }
                else
                {
                    currentIntevaal = nextInterval;
                    mergedIntervals.Add(currentIntevaal);
                }
            }

            return mergedIntervals.ToArray();
        }
    }
}