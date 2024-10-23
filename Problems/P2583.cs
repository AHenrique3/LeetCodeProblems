using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class P2583
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(KthLargestLevelSum(
                new TreeNode(5, 
                    new TreeNode(8,
                        new TreeNode(2,
                            new TreeNode(4),
                            new TreeNode(6)
                        ),
                        new TreeNode(1)
                    ),
                    new TreeNode(9,
                        new TreeNode(3),
                        new TreeNode(7)
                    )
                ), 2));
        }

        #region solving w recursion
        //public static long KthLargestLevelSum(TreeNode root, int k)
        //{
        //    var levels = new Dictionary<int, long>();
        //    Backtrack(root, levels, 0);
        //    var ordered = levels.OrderByDescending(x => x.Value).ToList();
        //    return k - 1 < ordered.Count ? ordered[k - 1].Value : -1;
        //}

        //public static void Backtrack(TreeNode node, Dictionary<int, long> levels, int level)
        //{
        //    if (levels.TryGetValue(level, out var result))
        //        levels[level] = result + node.val;
        //    else
        //        levels[level] = node.val;

        //    if (node.right != null)
        //        Backtrack(node.right, levels, level + 1);
        //    if (node.left != null)
        //        Backtrack(node.left, levels, level + 1);
        //}
        #endregion

        public static long KthLargestLevelSum(TreeNode root, int k)
        {
            var levels = new Dictionary<int, long>();
            Backtrack(root, levels, 0);
            var ordered = levels.OrderByDescending(x => x.Value).ToList();
            return k - 1 < ordered.Count ? ordered[k - 1].Value : -1;
        }

        public static void Backtrack(TreeNode node, Dictionary<int, long> levels, int level)
        {
            if (levels.TryGetValue(level, out var result))
                levels[level] = result + node.val;
            else
                levels[level] = node.val;

            if (node.right != null)
                Backtrack(node.right, levels, level + 1);
            if (node.left != null)
                Backtrack(node.left, levels, level + 1);
        }

        public class TreeNode
        {
            public int val;
            public TreeNode? left;
            public TreeNode? right;
            public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
