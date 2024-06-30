namespace OptimalFreelancing
{
    public class OptimalFreelancingClass
    {
        public int OptimalFreelancing(Dictionary<string, int>[] jobs)
        {
            const int LENGTH_OF_WEEK = 7;
            int profit = 0;
            Array.Sort(jobs, Comparer<Dictionary<string, int>>.Create((jobOne, JobTwo) => JobTwo["payment"]
            .CompareTo(jobOne["payment"])
                    )
            );

            bool[] timeline = new bool[LENGTH_OF_WEEK];

            foreach( var job in jobs ) 
            {
                int maxTime = Math.Min(job["deadline"], LENGTH_OF_WEEK);
                for (int time = maxTime-1; time >= 0; time--)
                {
                    if (!timeline[time])
                    {
                        timeline[time] = true;
                        profit += job["payment"];
                        break;
                    }
                }
            }

            return profit;
        }
    }
}