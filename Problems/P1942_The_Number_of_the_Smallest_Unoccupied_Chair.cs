using System.Collections.Generic;

namespace Problems
{
    public class P1942_The_Number_of_the_Smallest_Unoccupied_Chair
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(SmallestChair([[1, 4], [2, 3], [4, 6]], 1));

            Utilities.Output.Print("Test Case 2: ");
            Utilities.Output.PrintLine(SmallestChair([[3, 10], [1, 5], [2, 6]], 0));

            Utilities.Output.Print("Test Case 46: ");
            int[][] arr46 = [[33889, 98676], [80071, 89737], [44118, 52565], [52992, 84310], [78492, 88209], [21695, 67063], [84622, 95452], [98048, 98856], [98411, 99433], [55333, 56548], [65375, 88566], [55011, 62821], [48548, 48656], [87396, 94825], [55273, 81868], [75629, 91467]];
            Utilities.Output.PrintLine(SmallestChair(arr46, 6));
        }

        public static int SmallestChair(int[][] times, int targetFriend)
        {
            var target = times[targetFriend][0];

            var timeline = new List<Node>();
            for (int friendIndex = 0; friendIndex < times.Length; friendIndex++)
            {
                if (times[friendIndex][0] < target)
                    SortedAdd(timeline, new Node(times[friendIndex][0], times[friendIndex][1]));
            }
            if (timeline.Count == 0)
                return 0;

            timeline.Add(new Node(times[targetFriend][0], times[targetFriend][1]));

            var minChair = 0;
            var chairs = new List<Node>(timeline.Count);
            for (int i = 0; i < timeline.Count; i++)
            {
                var n = timeline[i];

                var seated = false;
                for (int j = 0; j < chairs.Count; j++)
                {
                    if (chairs[j].End <= n.Start)
                    {
                        seated = true;
                        minChair = j;
                        chairs[j] = n;
                        break;
                    }
                }
                if (!seated)
                {
                    minChair = chairs.Count;
                    chairs.Add(n);
                }
            }
            return minChair;
        }

        public static int SortedAdd(List<Node> source, Node item)
        {
            int index = source.BinarySearch(item);
            if (index < 0)
            {
                index = ~index;
            }

            source.Insert(index, item);
            return index;
        }

        public class Node : System.IComparable<Node>
        {
            public int Start;
            public int End;

            public Node(int start, int end)
            {
                Start = start;
                End = end;
            }

            public int CompareTo(Node? other)
            {
                if (other == null)
                    return 1;
                return Start < other?.Start ? -1 : 1;
            }
        }
    }
}