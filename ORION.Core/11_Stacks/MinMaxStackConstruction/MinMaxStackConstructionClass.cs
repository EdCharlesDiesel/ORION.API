namespace MinMaxStackConstruction
{
    public class MinMaxStackConstructionClass
    {
        List<Dictionary<string, int>> minMaxStack = new List<Dictionary<string, int>>();
        List<int> stack = new List<int>();
        // O(1) time | O(1) space
        public int Peek()
        {
            return stack[stack.Count - 1];
        }
        // O(1) time | O(1) space
        public int Pop()
        {
            minMaxStack.RemoveAt(minMaxStack.Count - 1);
            var val = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return val;
        }
        // O(1) time | O(1) space
        public void Push(int number)
        {
            Dictionary<string, int> newMinMax = new Dictionary<string, int>();
            newMinMax.Add("min", number);
            newMinMax.Add("max", number);
            if (minMaxStack.Count > 0)
            {
                Dictionary<string, int> lastMinMax = new Dictionary<string, int>(
                minMaxStack[minMaxStack.Count - 1]
                );
                newMinMax["min"] = Math.Min(lastMinMax["min"], number);
                newMinMax["max"] = Math.Max(lastMinMax["max"], number);
            }
            minMaxStack.Add(newMinMax);
            stack.Add(number);
        }
        // O(1) time | O(1) space
        public int GetMin()
        {
            return minMaxStack[minMaxStack.Count - 1]["min"];
        }
        // O(1) time | O(1) space
        public int GetMax()
        {
            return minMaxStack[minMaxStack.Count - 1]["max"];
        }
    }
}
