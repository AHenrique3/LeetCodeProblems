using System.Collections.Generic;

namespace Problems
{
    public class P3_Longest_Substring_Without_Repeating_Characters
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(LengthOfLongestSubstring("abcabcbb"));

            Utilities.Output.Print("Test Case 2: ");
            Utilities.Output.PrintLine(LengthOfLongestSubstring("bbbbb"));

            Utilities.Output.Print("Test Case 3: ");
            Utilities.Output.PrintLine(LengthOfLongestSubstring("pwwkew"));
        }

        public static int LengthOfLongestSubstring(string s)
        {
            var longest = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var j = i;
                var dictionary = new Dictionary<char, bool>();
                while (j < s.Length && !dictionary.ContainsKey(s[j]))
                {
                    dictionary[s[j]] = true;
                    j++;
                }
                if (dictionary.Count > longest)
                    longest = dictionary.Count;
            }
            return longest;
        }
    }
}