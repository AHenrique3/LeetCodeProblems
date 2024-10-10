using System.Collections.Generic;

namespace Problems
{
    public class P962_Maximum_Width_Ramp
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(MaxWidthRamp([6, 0, 8, 2, 1, 5]));
        }

        public static int MaxWidthRamp(int[] nums)
        {
            var st = new List<Node>();

            var maxRampWidth = 0;
            for (int numsIndex = 0; numsIndex < nums.Length; numsIndex++)
            {
                var pos = SortedAdd(st, new Node(nums[numsIndex], numsIndex));
                for (int j = pos - 1; j >= 0; j--)
                {
                    var rampWidth = numsIndex - st[j].Index;
                    if (rampWidth > maxRampWidth)
                        maxRampWidth = rampWidth;
                }
            }
            return maxRampWidth;
        }

        public static int SortedAdd(List<Node> source, Node item)
        {
            int index = source.BinarySearch(item, Node.Comp);
            if (index < 0)
            {
                index = ~index;
            }
            
            source.Insert(index, item);
            return index;
        }

        public class Node
        {
            public int Value;
            public int Index;
            public static readonly IComparer<Node> Comp = new NodeComparer();

            public Node(int value, int index)
            {
                Value = value;
                Index = index;
            }

            public override string ToString() => $"(\t{Value},\t{Index})";
        }

        public class NodeComparer : IComparer<Node>
        {
            public int Compare(Node? x, Node? y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (x == null) return -1;
                if (y == null) return 1;

                if (x.Value < y.Value)
                    return -1;
                if (x.Value == y.Value)
                {
                    if (x.Index < y.Index)
                        return -1;
                    if (x.Index > y.Index)
                        return 1;
                    return 0;
                }
                return 1;
            }
        }
    }
}