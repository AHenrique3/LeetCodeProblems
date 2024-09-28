namespace Problems
{
    public class P5_Longest_Palindromic_Substring
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(LongestPalindrome("babad"));

            Utilities.Output.Print("Test Case 2: ");
            Utilities.Output.PrintLine(LongestPalindrome("cbbd"));

            Utilities.Output.Print("Test Case 48: ");
            Utilities.Output.PrintLine(LongestPalindrome("ac"));
        }

        public static string LongestPalindrome(string s)
        {
            var longest = s.Length;
            var response = s;
            while (longest >= 1)
            {
                for (int i = 0; i <= s.Length - longest; i++)
                {
                    var substr = s.Substring(i, longest);
                    if (IsPalindrome(substr))
                        return substr;
                }
                longest--;
            }
            return response;
        }

        private static bool IsPalindrome(string s)
        {
            var half = s.Length / 2;
            for (int i = 0; i < half; i++)
            {
                if (s[i] != s[s.Length - i - 1])
                    return false;
            }
            return true;
        }
    }
}