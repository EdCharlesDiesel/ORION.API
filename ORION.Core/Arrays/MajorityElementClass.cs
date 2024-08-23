namespace ORION.Core.Arrays
{ 
    public class MajorityElementClass
    {
        public int MajorityElement(int[] array)
        {
            int answer = 0;

            for (int currentBit = 0; currentBit < 32; currentBit++)
            {
                int currentBitValue = 1 << currentBit;
                int onesCount = 0;
                foreach (int bit in array)
                {
                    if ((bit & currentBitValue) != 0)
                    {
                        onesCount++;
                    }
                }

                if (onesCount > array.Length /2)
                {
                    answer += currentBitValue;
                }
            }
             return answer;
            
        }

      

    }
}