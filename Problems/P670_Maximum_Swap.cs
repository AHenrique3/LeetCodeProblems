using System.Collections.Generic;

namespace Problems
{
    public class P670_Maximum_Swap
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(MaximumSwap(2736));

            Utilities.Output.Print("Test Case 2: ");
            Utilities.Output.PrintLine(MaximumSwap(9973));
        }

        public static int MaximumSwap(int num)
        {
            if (num < 10)
                return num;

            var digits = ListDigitsRev(num);

            var maxR = num;
            for (int i = 0; i < digits.Count - 1; i++)
            {
                for (int j = 1; j < digits.Count; j++)
                {
                    var digitsR = new List<byte>(digits);
                    if (digitsR[j] < digitsR[i])
                    {
                        (digitsR[j], digitsR[i]) = (digitsR[i], digitsR[j]);
                        var newN = CreateNumRev(digitsR);
                        if (maxR < newN)
                            maxR = newN;
                    }
                }
            }
            return maxR;
        }

        public static List<byte> ListDigitsRev(int n)
        {
            var digits = new List<byte>(10);
            while (n > 0)
            {
                digits.Add((byte)(n % 10));
                n /= 10;
            }
            return digits;
        }

        public static int CreateNumRev(List<byte> n)
        {
            var res = 0;
            for (int i = 0; i < n.Count; i++)
                res += n[i] * (int)System.Math.Pow(10, i);
            return res;
        }
    }
}
