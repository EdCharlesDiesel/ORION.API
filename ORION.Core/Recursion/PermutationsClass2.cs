namespace Permutations
{
    public class PermutationsClass2
    {
        // O(n*n!) time | O(n*n!) space
        public static List<List<int>> GetPermutations(List<int> array)
        {
            List<List<int>> permutations = new List<List<int>>();
            GetPermutations(0, array, permutations);
            return permutations;
        }

        public static void GetPermutations(int i, List<int> array, List<List<int>> permutations)
        {
            if (i == array.Count - 1)
            {
                permutations.Add(new List<int>(array));
            }
            else
            {
                for (int j = i; j < array.Count; j++)
                {
                    swap(array, i, j);
                    GetPermutations(i + 1, array, permutations);
                    swap(array, i, j);
                }
            }
        }

        public static void swap(List<int> array, int i, int j)
        {
            int tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }
}
