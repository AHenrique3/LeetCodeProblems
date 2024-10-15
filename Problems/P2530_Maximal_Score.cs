using System.Collections.Generic;

namespace Problems
{
    public class P2530_Maximal_Score
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(MaxKelements([10, 10, 10, 10, 10], 5));
        }

        public static long MaxKelements(int[] nums, int k)
        {
            var pq = new PriorityQueue<int, int>();
            for (int i = 0; i < nums.Length; i++)
                pq.Enqueue(nums[i], -nums[i]);

            var score = 0L;
            for (int i = 0; i < k; i++)
            {
                var val = pq.Dequeue();
                score += val;
                val = (val + 2) / 3;
                pq.Enqueue(val, -val);
            }
            return score;
        }
    }
}