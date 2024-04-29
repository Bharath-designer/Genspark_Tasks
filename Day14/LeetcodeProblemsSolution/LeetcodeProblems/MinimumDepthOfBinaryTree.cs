

namespace LeetcodeProblems
{
    public class TreeNode
    {
        public int value;
        public TreeNode leftNode;
        public TreeNode rightNode;
        public TreeNode(int value)
        {
            this.value = value;
            this.leftNode = null;
            this.rightNode = null;
        }
    }
    public class MinimumDepthOfBinaryTree
    {

        public TreeNode root;

        public void AddNodes(int[] values)
        {
            root = new TreeNode(values[0]);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int i = 1;
            while (queue.Count > 0 && i < values.Length)
            {
                TreeNode current = queue.Dequeue();

                if (values[i] != null)
                {
                    current.leftNode = new TreeNode(values[i]);
                    queue.Enqueue(current.leftNode);
                }
                i++;

                if (i < values.Length && values[i] != null)
                {
                    current.rightNode = new TreeNode(values[i]);
                    queue.Enqueue(current.rightNode);
                }
                i++;
            }
        }

        public int Solution()
        {
            return MinDepth(root);
        }

        int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            if (root.value == 0) return 0;

            int ls = MinDepth(root.leftNode);
            int rt = MinDepth(root.rightNode);

            if (ls == 0 || rt == 0) return 1 + Math.Max(ls, rt);

            return 1 + Math.Min(ls, rt);
        }
    }
}
