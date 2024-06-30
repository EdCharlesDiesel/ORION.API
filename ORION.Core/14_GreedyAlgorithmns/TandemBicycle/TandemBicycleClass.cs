namespace TandemBicycle;

/// <summary>
/// 
/// </summary>
public class TandemBicycleClass
{
    public int TandemBicycle(int[] redShirtSpeeds, int[] blueShirtSpeeds, bool fastest)
    {
        Array.Sort(redShirtSpeeds);
        Array.Sort(blueShirtSpeeds);

        if (!fastest)
        {
            ReverseArrayInPlace(redShirtSpeeds);
        }

        var totalSpeed = 0;
        for (int index = 0; index < redShirtSpeeds.Length; index++)
        {
            var riderOne = redShirtSpeeds[index];
            var riderTwo = blueShirtSpeeds[blueShirtSpeeds.Length - index -1];
            totalSpeed += Math.Max(riderOne, riderTwo);
        }
        return totalSpeed;
    }

    private void ReverseArrayInPlace(int[] redShirtSpeeds)
    {
        var start = 0;
        var end = redShirtSpeeds.Length - 1;
        while (start < end)
        {
            var temp = redShirtSpeeds[start];
            redShirtSpeeds[start] = redShirtSpeeds[end];
            redShirtSpeeds[end] = temp;
            start += 1;
            end -= 1;
        }
    }
}