namespace Problems
{
    public class P921_Minimum_Add_to_Make_Parentheses_Valid
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(MinAddToMakeValid("())"));

            Utilities.Output.Print("Test Case 45: ");
            Utilities.Output.PrintLine(MinAddToMakeValid("()))(("));
        }

        public static int MinAddToMakeValid(string s)
        {
            var result = 0;
            var counter = 0;
            foreach (var c in s)
            {
                if (c == '(')
                {
                    counter++;
                }
                if (c == ')')
                {
                    if(counter == 0)
                        result++;
                    else
                        counter--;
                }
            }
            return result+counter;
        }
    }
}