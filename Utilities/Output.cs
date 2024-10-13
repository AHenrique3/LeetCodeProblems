using System;
using System.Collections.Generic;

namespace Utilities
{
    public class Output
    {
        public static void Print(string obj) => Console.Write(obj);

        public static void PrintSkip(bool obj) => Console.Write(" " + obj + ",");

        public static void PrintLine(int obj) => Console.WriteLine(obj);
        public static void PrintLine(double obj) => Console.WriteLine(obj);
        public static void PrintLine(string obj) => Console.WriteLine(obj);

        public static void PrintLine<T>(IEnumerable<T> source) => Console.WriteLine($"[{string.Join(", ", source)}]");
    }

    public class Debug
    {
        public static void Print(string label) => System.Diagnostics.Debug.WriteLine(label);

        public static void PrintCollection<T>(string label, IEnumerable<T> source)
        {
            System.Diagnostics.Debug.WriteLine(label);
            foreach (T item in source)
                System.Diagnostics.Debug.WriteLine("\t" + item);
        }
    }
}