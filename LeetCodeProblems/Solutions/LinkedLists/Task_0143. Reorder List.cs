namespace Solutions.LinkedLists
{
    internal class Task_0143
    {
        // #Linked List #Two Pointers #Stack #Recursion

        public void ReorderList(ListNode head)
        {
            Solution1(head);
        }

        private void Solution1(ListNode head)
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

        private void Solution2(ListNode head)
        {
            if (head == null || head.next == null) return;

            ListNode slow = head, fast = head;
            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            ListNode prev = null, curr = slow.next;
            while (curr != null)
            {
                var nextTemp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextTemp;
            }
            slow.next = null;

            ListNode first = head, second = prev;
            while (first != null && second != null)
            {
                var firstNext = first.next;
                var secondNext = second.next;

                first.next = second;
                second.next = firstNext;

                first = firstNext;
                second = secondNext;
            }
        }
    }
}
