﻿namespace Solutions.LinkedLists
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

        private ListNode Solution2(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode tmp = ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            return tmp;
        }
    }
}
