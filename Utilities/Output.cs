using System;
using System.Collections.Generic;

namespace Utilities
{
    public class Output
    {
        public static void Print(string obj) => Console.Write(obj);

        public static void PrintSkip(bool obj) => Console.Write(" " + obj + ",");

        public static void PrintLine(bool obj) => Console.WriteLine(obj);
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

    public class Assert
    {
        public static void Check(string a, string b)
        {
            if (a != b)
                throw new Exception("Assert failed");
        }
        public static void CheckLen(string a, int b)
        {
            if (a.Length != b)
                throw new Exception("Assert failed");
        }

        public static void PrintCollection<T>(string label, IEnumerable<T> source)
        {
            System.Diagnostics.Debug.WriteLine(label);
            foreach (T item in source)
                System.Diagnostics.Debug.WriteLine("\t" + item);
        }
    }
}