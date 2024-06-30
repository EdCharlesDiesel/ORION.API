namespace StaircaseTraverse
{
    /// <summary>
    /// You're given two positive integers representing the
    /// height of a staircase and the maximum number of steps
    /// that you can advance up the staircase at at time. Write
    /// a function that returns the number of ways in the which
    /// you can climb the staircase.
    /// 
    /// For example, if you're given a staircase of height =3 and maxSteps
    /// = 2 you could clmb the staircase in 3 ways. You cound take
    /// step 1, 1 step, then 1 step, you could also take 1 step, 
    /// the 2 steps, and you could take 2 steps, then 1 step.
    /// 
    /// Note that maxSteps <= height will always be true.
    /// </summary>
    public static class StaircaseTraverse
    {
        public static int StaircaseTraversal(int height, int maxSteps)
        {
            return numberOfWaysToTheTop(height, maxSteps);
        }

        public static int numberOfWaysToTheTop(int height, int maxSteps)
        {
            if (height <= 1)
            {
                return 1;
            }

            int numberOfWays = 0;
            for (int step = 1; step < Math.Min(maxSteps,height) +1; step++)
            {
                numberOfWays += numberOfWaysToTheTop(height - step, maxSteps);
            }
            return numberOfWays;

        }
    }
}