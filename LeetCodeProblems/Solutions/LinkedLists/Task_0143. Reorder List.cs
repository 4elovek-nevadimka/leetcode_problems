namespace Solutions.LinkedLists
{
    internal class Task_0143
    {
        // #Linked List #Two Pointers #Stack #Recursion

        public void ReorderList(ListNode head)
        {
            if (head == null || head.next == null) return;

            ListNode slow = head, fast = head;
            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            var stack = new Stack<ListNode>();
            var curr = slow.next;
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.next;
            }

            var node = head;
            while (stack.Count > 0)
            {
                var nextNode = node.next;
                var poppedNode = stack.Pop();
                node.next = poppedNode;
                poppedNode.next = nextNode;
                node = nextNode;
            }
            node.next = null;
        }
    }
}
