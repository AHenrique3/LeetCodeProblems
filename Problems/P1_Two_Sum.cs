using System.Collections.Generic;

namespace Problems
{
    public class P1_Two_Sum
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(TwoSum(new int[] { 2, 7, 11, 15 }, 9));

            Utilities.Output.Print("Test Case 3: ");
            Utilities.Output.PrintLine(TwoSum(new int[] { 3, 3 }, 6));

            Utilities.Output.Print("Test Case 54: ");
            Utilities.Output.PrintLine(TwoSum(new int[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11));
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var store = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (store.TryGetValue(target - nums[i], out int value))
                    return [value, i];
                else
                    store.TryAdd(nums[i], i);
            }
            return [-1, -1];
        }
    }
}