namespace Problems
{
    public class P2938_Separate_Black_and_White_Balls
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(MinimumSteps("101"));

            Utilities.Output.Print("Test Case 2: ");
            Utilities.Output.PrintLine(MinimumSteps("100"));

            Utilities.Output.Print("Test Case 3: ");
            Utilities.Output.PrintLine(MinimumSteps("0111"));
        }

        public static long MinimumSteps(string s)
        {
            var answ = 0L;

            var oneSeq = 0L;
            var zeroSeq = 0L;
            var mode = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1')
                {
                    if (!mode)
                    {
                        answ += oneSeq * zeroSeq;
                        zeroSeq = 0;
                        mode = true;
                    }
                    oneSeq++;
                }
                if (s[i] == '0' && oneSeq > 0)
                {
                    mode = false;
                    zeroSeq++;
                }
            }
            answ += oneSeq * zeroSeq;

            return answ;
        }
    }
}