namespace Solutions.LinkedLists
{
    internal class Task_0141
    {
        // #Hash Table #Linked List #Two Pointers

        public bool HasCycle(ListNode head)
        {
            return Solution1(head);
        }

        private bool Solution1(ListNode head)
        {
            if (head == null || head.next == null)
                return false;

            ListNode start = head, previous = null;
            while (head.next != null)
            {
                var tmp = previous;
                previous = head;
                head = head.next;
                previous.next = tmp;
            }

            return start == head;
        }

        private bool Solution2(ListNode head)
        {
            ListNode fast = head, slow = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (fast == slow)
                    return true;
            }
            return false;
        }
    }
}
