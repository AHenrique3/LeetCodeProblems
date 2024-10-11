using System.Linq;

namespace Problems
{
    public class P962_Maximum_Width_Ramp
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(MaxWidthRamp([6, 0, 8, 2, 1, 5]));
        }

        public static int MaxWidthRamp(int[] nums)
        {
            var maxRampWidth = 0;
            var prevIndex = -1;
            foreach (var tup in nums.Select((num, index) => (num, index)).OrderBy(tup => tup.num))
            {
                if (prevIndex == -1)
                    prevIndex = tup.index;

                var width = tup.index - prevIndex;
                if (width > 0 && width > maxRampWidth)
                    maxRampWidth = width;
                if (tup.index < prevIndex)
                    prevIndex = tup.index;
            }
            return maxRampWidth;
        }
    }
}