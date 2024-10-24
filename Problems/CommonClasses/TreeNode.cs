using System.Collections.Generic;

namespace Problems.CommonClasses
{
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

        public override string ToString()
        {
            return $"{val} L({left} R({right}))";
        }

        public static TreeNode? CreateTestCase(int?[] sample)
        {
            if (sample.Length == 0)
                return null;

            var root = new TreeNode(sample[0]!.Value);
            var i = 1;
            var parents = new List<TreeNode?> { root };
            var newParents = new List<TreeNode?>(2);
            while (i < sample.Length)
            {
                for (var j = 0; j < parents.Count; j++)
                {
                    var parent = parents[j];

                    var sampleValL = i < sample.Length ? sample[i++] : null;
                    var sampleValR = i < sample.Length ? sample[i++] : null;
                    if (parent != null)
                    {
                        if (sampleValL != null)
                            parent.left = new TreeNode(sampleValL.Value);
                        if (sampleValR != null)
                            parent.left = new TreeNode(sampleValR.Value);
                    }
                    newParents.Add(parent?.left);
                    newParents.Add(parent?.right);
                }
                (parents, newParents) = (newParents, parents);
                newParents.Clear();
            }

            return root;
        }
    }
}