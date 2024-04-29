

namespace LeetcodeProblems
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
    public class LinkedList
    {
        ListNode root;


        public void AddNode(ListNode node)
        {
            if (root == null)
            {
                root = node;
            }
            else
            {
                AddNode(root, node);
            }
        }

        private void AddNode(ListNode current, ListNode node)
        {
            if (current.next == null)
            {
                current.next = node;
            }
            else
            {
                AddNode(current.next, node);
            }
        }


        public bool HasCycle()
        {
            return HasCycle(root);
        }
        private bool HasCycle(ListNode head)
        {
            ListNode pointer1 = head, pointer2 = head;
            while (pointer2 != null && pointer2.next != null)
            {
                pointer1 = pointer1.next;
                pointer2 = pointer2.next.next;
                if (pointer1 == pointer2)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
