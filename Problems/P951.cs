using Problems.CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class P951
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(
                FlipEquiv(
                    new TreeNode(5,
                        new TreeNode(4,
                            new TreeNode(1),
                            new TreeNode(10)
                        ),
                        new TreeNode(9,
                            null,
                            new TreeNode(7)
                        )
                    ),
                    new TreeNode(5,
                        new TreeNode(4,
                            new TreeNode(1),
                            new TreeNode(10)
                        ),
                        new TreeNode(9,
                            null,
                            new TreeNode(7)
                        )
                    )
                )
            );
            Utilities.Output.Print("Test Case 2: ");
            Utilities.Output.PrintLine(
                FlipEquiv(
                    TreeNode.CreateTestCase([1, 2, 3, 4, 5, 6, null, null, null, 7, 8]),
                    TreeNode.CreateTestCase([1, 3, 2, null, 6, 4, 5, null, null, null, null, 8, 7])
                )
            );
            Utilities.Output.Print("Test Case 3: ");
            Utilities.Output.PrintLine(
                FlipEquiv(
                    TreeNode.CreateTestCase([]),
                    TreeNode.CreateTestCase([1])
                )
            );
        }

        public static bool FlipEquiv(TreeNode? root1, TreeNode? root2)
        {
            if (root1 == null && root2 == null)//Fast short circuit
                return true;
            if (root1?.val != root2?.val)//Fast short circuit
                return false;

            return Backtrack([root1], [root2]);
        }

        public static bool Backtrack(List<TreeNode?> parents1, List<TreeNode?> parents2)
        {
            var newParents1 = new List<TreeNode?>(parents1.Count);
            var newParents2 = new List<TreeNode?>(parents2.Count);

            while (parents1.Count > 0 && parents2.Count > 0)
            {
                if (parents1.Count != parents2.Count)
                    return false;

                for (int i = 0; i < parents1.Count; i++)
                {
                    var parent1 = parents1[i];
                    var parent2 = parents2[i];

                    if (parent1?.left?.val == parent2?.left?.val && parent1?.right?.val == parent2?.right?.val)
                    {
                        newParents1.Add(parent1?.left);
                        newParents1.Add(parent1?.right);
                        newParents2.Add(parent2?.left);
                        newParents2.Add(parent2?.right);
                    }
                    else if (parent1?.left?.val == parent2?.right?.val && parent1?.right?.val == parent2?.left?.val)
                    {
                        newParents1.Add(parent1?.left);
                        newParents1.Add(parent1?.right);
                        newParents2.Add(parent2?.right);
                        newParents2.Add(parent2?.left);
                    }
                    else
                        return false;
                }

                if (newParents1.All(x => x == null) && newParents2.All(x => x == null))
                    break;

                (parents1, newParents1) = (newParents1, parents1);
                newParents1.Clear();
                (parents2, newParents2) = (newParents2, parents2);
                newParents2.Clear();
            }

            return true;
        }
    }
}