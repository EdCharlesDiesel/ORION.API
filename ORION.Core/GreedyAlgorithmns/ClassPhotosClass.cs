using System.Collections.Generic;

namespace ORION.Core.GreadyAlgorithmns
{
    public class ClassPhotosClass
    {
        public bool ClassPhotos(List<int> redShirtHeights, List<int> blueShirtHeights)
        {
            redShirtHeights.Sort((a, b) => b.CompareTo(a));
            blueShirtHeights.Sort((a, b) => b.CompareTo(a));

            string shirtColorInFirstRow =
                (redShirtHeights[0] < blueShirtHeights[0]) ? "RED" : "BLUE";
            for (int i = 0; i < redShirtHeights.Count; i++)
            {
                int redShirtHeight = redShirtHeights[i];
                int blueShirtHeight = blueShirtHeights[i];

                if (shirtColorInFirstRow == "RED")
                {
                    if (redShirtHeight >= blueShirtHeight)
                    {
                        return false;
                    }
                }
                else
                {
                    if (blueShirtHeight >= redShirtHeight)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}