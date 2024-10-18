namespace Problems
{
    public class P2044_Count_Numbers
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(CountMaxOrSubsets([3, 1]));
            Utilities.Output.Print("Test Case 2: ");
            Utilities.Output.PrintLine(CountMaxOrSubsets([2, 2, 2]));
            Utilities.Output.Print("Test Case 3: ");
            Utilities.Output.PrintLine(CountMaxOrSubsets([3, 2, 1, 5]));
        }

        #region BruteForce
        //public static int CountMaxOrSubsets(int[] nums)
        //{
        //    var maxBitwise = nums.Aggregate((res, next) => res | next);
        //    var subsets = 1;
        //    for (int subgSize = 1; subgSize < nums.Length; subgSize++)
        //    {
        //        foreach (var subg in Combinations(nums, 0, subgSize))
        //        {
        //            if (subg.Aggregate((res, next) => res | next) == maxBitwise)
        //                subsets++;
        //        }
        //    }
        //    return subsets;
        //}

        //public static IEnumerable<IEnumerable<int>> Combinations(int[] group, int start, int size)
        //{
        //    if (size == 1)
        //    {
        //        for (var i = start; i < group.Length; i++)
        //            yield return [group[i]];
        //    }
        //    else
        //    {
        //        for (var i = start; i < group.Length; i++)
        //        {
        //            foreach (var item in Combinations(group, i + 1, size - 1))
        //                yield return [group[i], ..item];
        //        }
        //    }
        //}
        #endregion
        #region BruteForce-Enhanced
        //public static int CountMaxOrSubsets(int[] nums)
        //{
        //    var maxOR = 0;
        //    for (int i = 0; i < nums.Length; i++)
        //        maxOR |= nums[i];

        //    var subsets = 1;
        //    for (int subgSize = 1; subgSize < nums.Length; subgSize++)
        //        subsets += CombOR(nums, 0, subgSize, maxOR, 0);
        //    return subsets;
        //}

        //public static int CombOR(int[] group, int start, int size, int target, int trail)
        //{
        //    var matches = 0;
        //    if (size == 1)
        //    {
        //        for (var i = start; i < group.Length; i++)
        //            matches += (trail | group[i]) == target ? 1 : 0;
        //    }
        //    else
        //    {
        //        for (var i = start; i < group.Length; i++)
        //            matches += CombOR(group, i + 1, size - 1, target, trail | group[i]);
        //    }
        //    return matches;
        //}
        #endregion
        #region Improving from the best
        public static int CountMaxOrSubsets(int[] nums)
        {
            var maxOr = 0;
            return Backtrack(nums, 0, 0, 0, ref maxOr);
        }

        public static int Backtrack(int[] nums, int index, int acc, int beat, ref int maxAcc)
        {
            if (index == nums.Length)
            {
                if (beat == nums.Length)
                    maxAcc = acc;
                return acc == maxAcc ? 1 : 0;
            }
            return Backtrack(nums, index + 1, acc | nums[index], beat + 1, ref maxAcc)
                 + Backtrack(nums, index + 1, acc              , beat    , ref maxAcc);
        }
        #endregion
    }
}