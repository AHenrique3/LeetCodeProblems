using System.Collections.Generic;

namespace Problems
{
    public class P1593_Split_a_String
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(MaxUniqueSplit("ababccc"));

            Utilities.Output.Print("Test Case 2: ");
            Utilities.Output.PrintLine(MaxUniqueSplit("aba"));

            Utilities.Output.Print("Test Case 3: ");
            Utilities.Output.PrintLine(MaxUniqueSplit("aa"));

            Utilities.Output.Print("Test Case X: ");
            Utilities.Output.PrintLine(MaxUniqueSplit("wwwzfvedwfvhsww"));
        }

        public static int MaxUniqueSplit(string s)
        {
            var maxSplits = 0;
            Backtrack(s, 0, [], 0, ref maxSplits);
            return maxSplits;
        }

        public static void Backtrack(string s, int index, HashSet<string> substrings, int count, ref int maxAcc)
        {
            if (index == s.Length)
            {
                if (count > maxAcc)
                    maxAcc = count;
                return;
            }

            for (int i = index + 1; i <= s.Length; i++)
            {
                var sub = s.Substring(index, i - index);
                if (!substrings.Contains(sub))
                {
                    substrings.Add(sub);
                    Backtrack(s, i, substrings, count + 1, ref maxAcc);
                    substrings.Remove(sub);
                }
            }
        }
    }
}
