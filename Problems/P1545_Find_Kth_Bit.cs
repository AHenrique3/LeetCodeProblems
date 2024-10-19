using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class P1545_Find_Kth_Bit
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine("" + FindKthBit(3, 1));
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine("" + FindKthBit(4,11));
        }

        public static char FindKthBit(int n, int k)
        {
            return GetOrCreateString(n)[k - 1]; 
        }

        public static readonly Dictionary<int, string> StringStore = [];
        public static string GetOrCreateString(int n)
        {
            if (n == 1)
                return "0";
            if (!StringStore.ContainsKey(n))
            {
                var prev = GetOrCreateString(n - 1);
                StringStore[n] = prev + "1" + string.Concat(prev.Reverse().Select(x => x == '0' ? '1' : '0'));
            }
            return StringStore[n];
        }
    }
}