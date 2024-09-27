using System.Collections.Generic;

namespace Problems
{
    public class P2416_Sum_Of_Prefix_Scores_Of_Strings
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(SumPrefixScores(["abc", "ab", "bc", "b"]));
        }

        public static int[] SumPrefixScores(string[] words)
        {
            var result = new int[words.Length];

            var root = Node.Create(words);
            for (int i = 0; i < words.Length; i++)
            {
                result[i] = root.SumWeight(words[i]);
            }

            return result;
        }

        public class Node
        {
            public int Weight { get; set; }
            public Dictionary<int, Node> Childs { get; set; }

            public Node()
            {
                Weight = 0;
                Childs = new Dictionary<int, Node>();
            }

            public void Append(string n)
            {
                var node = this;
                foreach (var c in n)
                {
                    if (!node.Childs.ContainsKey(c))
                        node.Childs.Add(c, new Node());

                    node.Childs[c].Weight++;
                    node = node.Childs[c];
                }
            }

            public static Node Create(IEnumerable<string> source)
            {
                var node = new Node();
                foreach (var elem in source)
                    node.Append(elem);
                return node;
            }

            public int SumWeight(string source)
            {
                var sum = 0;
                var node = this;
                foreach (var c in source)
                {
                    var next = node.Childs.ContainsKey(c) ? node.Childs[c] : null;
                    if (next == null)
                        break;
                    else
                    {
                        node = next;
                        sum += node.Weight;
                    }
                }
                return sum;
            }
        }
    }
}