

namespace SweetAndSavory
{
    public class SweetAndSavoryClass
    {
        public int[] SweetAndSavory(int[] dishes, int target)
        {
            List<int> sweetDishes = new List<int>();
            List<int> savouryDishes = new List<int>();

            foreach (var dish in dishes)
            {
                if (dish<0)
                {
                    sweetDishes.Add(dish);
                }
                else
                {
                    savouryDishes.Add(dish);    
                }
            }

            sweetDishes.Sort((a,b)=>Math.Abs(a) - Math.Abs(b));
            savouryDishes.Sort();

            int[] bestPair = new int[2];
            int bestDifference = Int32.MaxValue;
            int sweetIndex = 0, savoryIndex = 0;

            while (sweetIndex < sweetDishes.Count && savoryIndex< savouryDishes.Count)
            {
                int currentSum = sweetDishes[sweetIndex] + savouryDishes[savoryIndex];

                if (currentSum <= target)
                {
                    int currentDifference = target - currentSum;
                    if (currentDifference < bestDifference)
                    {
                        bestDifference = currentDifference;
                        bestPair[0] = sweetDishes[sweetIndex];
                        bestPair[1] = savouryDishes[savoryIndex];
                    }
                    savoryIndex++;

                }
                else
                {
                    savoryIndex++;
                }
            }

            return bestPair;
        }
    }
}