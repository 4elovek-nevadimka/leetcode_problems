namespace Solutions.LinkedLists
{
    internal class Task_2487
    {
        // #Linked List #Stack #Recursion #Monotonic Stack

        public ListNode RemoveNodes(ListNode head)
        {
            var stack = new Stack<int>();
            while (head != null)
            {
                stack.Push(head.val);
                head = head.next;
            }

            var newHead = new ListNode(stack.Pop());
            while (stack.Count > 0)
            {
                var curNodeVal = stack.Pop();
                if (curNodeVal >= newHead.val)
                {
                    newHead = new ListNode(curNodeVal, newHead);
                }
            }

            return newHead;
        }
    }
}
