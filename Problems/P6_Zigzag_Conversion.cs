using System;
using System.Text;

namespace Problems
{
    public class P6_Zigzag_Conversion
    {
        public static void RunTests()
        {
            var res = Convert("PAYPALISHIRING", 3);
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(res);

            res = Convert("PAYPALISHIRING", 4);
            Utilities.Output.Print("Test Case 2: ");
            Utilities.Output.PrintLine(res);

            res = Convert("AB", 1);
            Utilities.Output.Print("Test Case 8: ");
            Utilities.Output.PrintLine(res);
        }

        public static string Convert(string s, int numRows)
        {
            if(numRows < 2)
                return s;

            var numCols = s.Length;
            var mat = new char[numRows, numCols];
            var row = 0;
            var col = 0;
            var rowAcc = 1;
            var colAcc = 0;
            for (int i = 0; i < s.Length; i++)
            {
                mat[row, col] = s[i];

                if (row == numRows - 1)
                {
                    rowAcc = -1;
                    colAcc = 1;
                }
                else if (row == 0 && col > 0)
                {
                    rowAcc = 1;
                    colAcc = 0;
                }

                row += rowAcc;
                col += colAcc;
            }

            var result = new StringBuilder(s.Length);
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                    if (mat[i, j] != 0)
                        result.Append(mat[i, j]);
            }

            return result.ToString();
        }
    }
}