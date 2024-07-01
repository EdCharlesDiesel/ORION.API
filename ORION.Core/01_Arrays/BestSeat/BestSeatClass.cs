namespace BestSeat
{
    /// <summary>
    /// You walk inti a theatre you're about to see a show in. The usher within the theatre walks
    /// you to your row and mentioned you're allowed to sit anywhere within the given row. Natually
    /// you'd like to sit in the seat that gives you the most space.
    /// </summary>
    public class BestSeatClass
    {
        public int BestSeat(int[] seats)
        {
            int bestSeat = -1;
            int maxSpace = 0;

            int left = 0;
            while (left < seats.Length)
            {
                int right = left + 1;
                while (right < seats.Length && seats[right]==0)
                {
                    right++;
                }

                int availableSpace= right - left-1;
                if (availableSpace > maxSpace)
                {
                    bestSeat = (left + right) / 2;
                    maxSpace = availableSpace;
                }
                left = right;
            }
            return bestSeat;
        }
    }
}