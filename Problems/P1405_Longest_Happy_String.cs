using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems
{
    public class P1405_Longest_Happy_String
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(LongestDiverseString(1, 1, 7));
            Utilities.Output.Print("Test Case 2: ");
            Utilities.Output.PrintLine(LongestDiverseString(7, 1, 0));
        }

        public static string LongestDiverseString(int a, int b, int c)
        {
            var sb = new StringBuilder();

            var hsa = new HappySource('a', a);
            var hsb = new HappySource('b', b);
            var hsc = new HappySource('c', c);

            var col = new PriorityQueue<HappySource, int>();
            if (a > 0)
                col.Enqueue(hsa, -a);
            if (b > 0)
                col.Enqueue(hsb, -b);
            if (c > 0)
                col.Enqueue(hsc, -c);

            HappySource? hold = null;
            while (col.Count > 0)
            {
                var st = col.Dequeue();

                if (st.Times > 1 && Dominant(hsa, hsb, hsc, st.Times))
                    sb.Append(st.Take());
                sb.Append(st.Take());

                if (hold != null)
                {
                    col.Enqueue(hold, -hold.Times);
                    hold = null;
                }
                if (st.Times > 0)
                    hold = st;
            }

            return sb.ToString();
        }

        static bool Dominant(HappySource hsa, HappySource hsb, HappySource hsc, int size)
        {
            return (new[] { hsa.Times, hsb.Times, hsc.Times }).Max() == size;
        }

        public class HappySource
        {
            public char Chr { get; set; }
            public int Times { get; set; }

            public HappySource(char chr, int times) { Chr = chr; Times = times; }
            public int Available => Times > 0 ? 1 : 0;
            public char Take()
            {
                if (Times > 0) { Times--; return Chr; } throw new Exception();
            }
            public override string ToString() => $"({Chr} x{Times})";
        }

        public class CircularCollection
        {
            public List<HappySource> Values { get; set; }
            public int Count => Values.Count;
            private int _count = -1;

            public CircularCollection(params HappySource[] values)
            {
                Values = [.. values.Where(x => x.Times > 0).OrderByDescending(x => x.Times)];
            }

            public HappySource Next()
            {
                _count = (_count + 1) % Count;
                return Values[_count];
            }
            public void Remove() => Values.RemoveAt(_count);
            public override string ToString() => $"[{string.Join(",", Values)}]";
        }
    }
}