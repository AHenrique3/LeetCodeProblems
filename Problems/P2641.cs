using System.Collections.Generic;

namespace Problems
{
    public class P2641
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(ReplaceValueInTree(
                new TreeNode(5,
                    new TreeNode(4,
                        new TreeNode(1),
                        new TreeNode(10)
                    ),
                    new TreeNode(9,
                        null,
                        new TreeNode(7)
                    )
                )) != null);
        }

        public static TreeNode ReplaceValueInTree(TreeNode root)
        {
            root.val = 0;
            Backtrack([root]);
            return root;
        }

        public static void Backtrack(List<TreeNode> parents)
        {
            var nextLevel = new List<TreeNode>(parents.Count);
            while (parents.Count > 0)
            {
                var sum = 0;
                for (int i = 0; i < parents.Count; i++)
                {
                    var node = parents[i];
                    if (node.left != null)
                    {
                        sum += node.left.val;
                        nextLevel.Add(node.left);
                    }
                    if (node.right != null)
                    {
                        sum += node.right.val;
                        nextLevel.Add(node.right);
                    }
                }
                for (int i = 0; i < parents.Count; i++)
                {
                    var node = parents[i];
                    var cousinsSum = sum - ((parents[i].left?.val ?? 0) + (parents[i].right?.val ?? 0));

                    if (node.left != null)
                        node.left.val = cousinsSum;
                    if (node.right != null)
                        node.right.val = cousinsSum;
                }
                if (nextLevel.Count > 0)
                {
                    parents.Clear();
                    parents.AddRange(nextLevel);
                    nextLevel.Clear();
                }
                else
                    break;
            }
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
