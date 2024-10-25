using System.Collections.Generic;
using System.Text;

namespace Problems
{
    public class P1233
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(RemoveSubfolders(["/a", "/a/b", "/c/d", "/c/d/e", "/c/f"]));

            Utilities.Output.Print("Test Case 2: ");
            Utilities.Output.PrintLine(RemoveSubfolders(["/a", "/a/b/c", "/a/b/d"]));

            Utilities.Output.Print("Test Case 3: ");
            Utilities.Output.PrintLine(RemoveSubfolders(["/a/b/c", "/a/b/ca", "/a/b/d"]));
        }

        public static IList<string> RemoveSubfolders(string[] folder)
        {
            var rootPaths = new Node("");

            foreach (var path in folder)
            {
                var nodePoint = rootPaths;

                var nodeVals = path.Split('/', System.StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < nodeVals.Length; i++)
                {
                    if (nodePoint.TryGetChild(nodeVals[i], out var childNode))
                    {
                        if (childNode != null)
                        {
                            if (childNode.Terminal == false && i == nodeVals.Length - 1)
                                childNode.Terminal = true;
                            nodePoint = childNode!;
                        }
                    }
                    else
                    {
                        var nNode = new Node(nodeVals[i], i == nodeVals.Length - 1);
                        nodePoint.Add(nNode);
                        nodePoint = nNode;
                    }
                }
            }

            var res = new List<string>();
            foreach (var child in rootPaths.Childs.Values)
                Node.MountTerminals(child, "", res);
            return res;
        }

        public class Node
        {
            public string Value { get; set; }
            public bool Terminal { get; set; }
            public Dictionary<string, Node> Childs { get; set; }

            public Node(string value) { Value = value; Childs = []; }
            public Node(string value, bool term) { Value = value; Childs = []; Terminal = term; }

            public bool TryGetChild(string val, out Node? child) => Childs.TryGetValue(val, out child);
            public void Add(Node child) => Childs.Add(child.Value, child);

            public override string ToString()
            {
                return $"{Value}.{(Terminal?1:0)}";
            }

            public static void MountTerminals(Node root, string path, List<string> mounts)
            {
                path += '/' + root.Value;
                if (root.Childs.Count == 0 || root.Terminal)
                    mounts.Add(path);
                else
                {
                    foreach (var mount in root.Childs.Values)
                    {
                        MountTerminals (mount, path, mounts);
                    }
                }
            }
        }
    }
}