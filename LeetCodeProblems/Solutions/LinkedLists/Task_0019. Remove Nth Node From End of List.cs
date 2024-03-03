namespace Solutions.LinkedLists
{
    internal class Task_0019
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var list = new List<ListNode>(30);
            var node = head;
            list.Add(node);
            while (node.next != null)
            {
                node = node.next;
                list.Add(node);
            }
            if (list.Count == n)
                return n == 1 ? null : list[^(n - 1)];

            if (n == 1)
                list[^2].next = null;
            else
                list[^(n + 1)].next = list[^(n - 1)];

            return head;
        }
    }
}
