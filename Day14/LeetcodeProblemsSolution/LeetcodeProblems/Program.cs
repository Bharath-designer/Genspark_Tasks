namespace LeetcodeProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MinimumDepthOfBinaryTree minimumDepthOfBinaryTree = new MinimumDepthOfBinaryTree();
            AddTreeSampleData(minimumDepthOfBinaryTree);
            int problem1Solution1 = minimumDepthOfBinaryTree.Solution();
            Console.WriteLine("Solution For Task 1: " + problem1Solution1);
            Console.WriteLine();

            ExcelSheetColumnTitle excelSheetColumnTitle = new ExcelSheetColumnTitle();
            string problem2Solution2 = excelSheetColumnTitle.Solution(701);
            Console.WriteLine("Solution For Task 2: " + problem2Solution2);
            Console.WriteLine();

            LinkedList linkedList = new LinkedList();
            AddLinkedListSampleData(linkedList);
            bool hasCycle = linkedList.HasCycle();
            if (hasCycle)
            {
                Console.WriteLine("Solution For Task 3: The LinkedList has Cycle");
            } else
            {
                Console.WriteLine("Solution For Task 3: The LinkedList does't have Cycle");
            }

        }

        static void AddTreeSampleData(MinimumDepthOfBinaryTree tree)
        {
            int[] nodes = { 3, 9, 20, 0, 0, 15, 7 };
            tree.AddNodes(nodes);
            
        }

        static void AddLinkedListSampleData(LinkedList linkedList)
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(5);
            ListNode node6 = new ListNode(6);
            ListNode node7 = new ListNode(7);
            ListNode node8 = new ListNode(8);
            linkedList.AddNode(node1);
            linkedList.AddNode(node2);
            linkedList.AddNode(node3);
            linkedList.AddNode(node4);
            linkedList.AddNode(node5);
            linkedList.AddNode(node6);
            linkedList.AddNode(node7);
            linkedList.AddNode(node8);
            linkedList.AddNode(node5); // Creating LinkedList Cycle here

        }
    }
}
