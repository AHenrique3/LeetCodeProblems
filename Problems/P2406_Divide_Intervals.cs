using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class P2406_Divide_Intervals
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(MinGroups([[5, 10], [6, 8], [1, 5], [2, 3], [1, 10]]));

            Utilities.Output.Print("Test Case 2: ");
            Utilities.Output.PrintLine(MinGroups([[1, 3], [5, 6], [8, 10], [11, 13]]));

            Utilities.Output.Print("Test Case 3: ");
            Utilities.Output.PrintLine(MinGroups([[1,1]]));
        }

        public static int MinGroups(int[][] intervals)
        {
            var max = 0;
            var count = 0;
            foreach (var interval in intervals.SelectMany(x => new List<(int, int)> { (x[0], 1), (x[1], -1) })
                .OrderBy(x => x.Item1).ThenByDescending(x => x.Item2))
            {
                count += interval.Item2;
                if (count > max)
                    max = count;
            }
            return max;
        }
    }
}