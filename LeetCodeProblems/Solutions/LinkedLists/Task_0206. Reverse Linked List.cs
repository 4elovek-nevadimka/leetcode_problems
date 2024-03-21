namespace Solutions.LinkedLists
{
    internal class Task_0206
    {
        // #Linked List #Recursion

        public ListNode ReverseList(ListNode head)
        {
            return Solution1(head);
        }

        private ListNode Solution1(ListNode head)
        {
            if (head == null)
                return null;

            ListNode previous = null;
            while (head.next != null)
            {
                var tmp = previous;
                previous = head;
                head = head.next;
                previous.next = tmp;
            }
            head.next = previous;
            return head;
        }

        //private ListNode Solution2(ListNode head)
        //{
        //    if (head == null)
        //        return null;
        //    return Reverse(head, null);
        //}

        //private ListNode Reverse(ListNode node, ListNode prev)
        //{
        //    if (node.next == null)
        //    {
        //        node.next = prev;
        //        return node;
        //    }

        //    prev?.next = node;
        //    return Reverse(node.next, node);
        //}
    }
}
