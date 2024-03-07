namespace Solutions.LinkedLists
{
    internal class Task_0876
    {
        // #Linked List #Two Pointers

        public ListNode MiddleNode(ListNode head)
        {
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
    }
}
