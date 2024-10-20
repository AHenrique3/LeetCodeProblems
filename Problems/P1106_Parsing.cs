using System;

namespace Problems
{
    public class P1106_Parsing
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(ParseBoolExpr("&(|(f))"));

            Utilities.Output.Print("Test Case 2: ");
            Utilities.Output.PrintLine(ParseBoolExpr("|(f,f,f,t)"));

            Utilities.Output.Print("Test Case X: ");
            Utilities.Output.PrintLine(ParseBoolExpr("|(&(t,f,t),!(t))"));
        }

        public static bool ParseBoolExpr(string expression)
        {
            var enn = expression.GetEnumerator();
            enn.MoveNext();
            return ParseBoolExpr(enn);
        }

        public static bool ParseBoolExpr(CharEnumerator expression)
        {
            if (expression.Current == '&')
                return EvalFn(expression, expression.Current);
            else if (expression.Current == '|')
                return EvalFn(expression, expression.Current);
            else if (expression.Current == '!')
                return EvalFn(expression, expression.Current);
            else if (expression.Current == 't')
            {
                expression.MoveNext();
                return true;
            }
            else //if (expression == "f")
            {
                expression.MoveNext();
                return false;
            }
        }

        public static bool EvalFn(CharEnumerator expression, char fn)
        {
            expression.MoveNext();//Jump fn
            expression.MoveNext();//Jump (

            var res = true;
            if (fn == '&')
            {
                while (expression.Current != ')')
                {
                    res &= ParseBoolExpr(expression);
                    if (expression.Current == ',')
                        expression.MoveNext();
                }
            }
            else if (fn == '|')
            {
                res = false;
                while (expression.Current != ')')
                {
                    res |= ParseBoolExpr(expression);
                    if (expression.Current == ',')
                        expression.MoveNext();
                }
            }
            else if (fn == '!')
                res = !ParseBoolExpr(expression);

            expression.MoveNext();//Jump )
            return res;
        }
    }
}
