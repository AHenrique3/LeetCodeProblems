using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class P632_Smallest_Range
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(SmallestRange([[4, 10, 15, 24, 26], [0, 9, 12, 20], [5, 18, 22, 30]]));
        }

        public static int[] SmallestRange(IList<IList<int>> nums)
        {
            var smallestRange = new int[] { 0, 0 };
            var rangeSize = int.MaxValue;

            var seq = new Window(nums.Count);
            foreach (var point in Transform(nums).OrderBy(x => x.Item1))
            {
                var rg = seq.Add(point);
                if (rg == null)
                    continue;
                else
                {
                    var rgs = rg.Value.Item2 - rg.Value.Item1;
                    if (rgs < rangeSize)
                    {
                        smallestRange[0] = rg.Value.Item1;
                        smallestRange[1] = rg.Value.Item2;
                        rangeSize = rgs;
                    }
                }
            }
            return smallestRange;
        }
        public static IEnumerable<(int, int)> Transform(IList<IList<int>> nums)
        {
            for (int i = 0; i < nums.Count; i++)
                for (int j = 0; j < nums[i].Count; j++)
                    yield return (nums[i][j], i);
        }

        public class Window
        {
            public Queue<(int,int)> Sequence { get; set; }
            public Checker Checker { get; set; }
            public bool Filled { get; set; }

            public Window(int target)
            {
                Sequence = new Queue<(int, int)>();
                Checker = new Checker(target);
            }

            public (int, int)? Add((int,int) val)
            {
                (int, int)? res = null;
                Sequence.Enqueue(val);
                if (Checker.Put(val.Item2))
                {
                    while (Checker.TryTake(Sequence.Peek().Item2))
                        Sequence.Dequeue();
                    res = (Sequence.Peek().Item1, val.Item1);
                }
                return res;
            }
        }

        public class Checker
        {
            public int[] Accs { get; set; }
            public int Target { get; set; }
            public int Sum { get; set; }

            public Checker(int target) { Accs = new int[target]; Target = target; }

            public bool Put(int val)
            {
                Accs[val]++;
                if (Accs[val] == 1)
                    Sum++;
                return Sum == Target;
            }

            public bool TryTake(int val)
            {
                if (Accs[val] <= 1)
                    return false;
                Accs[val]--;
                return true;
            }
        }
    }
}