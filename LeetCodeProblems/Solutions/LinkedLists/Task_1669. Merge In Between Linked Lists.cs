namespace Solutions.LinkedLists
{
    internal class Task_1669
    {
        // #Linked List

        public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
        {
            var index = 0;
            ListNode nodeA = null, node = list1;
            while (!(node.next == null || index == b))
            {
                if (index == a - 1)
                    nodeA = node;
                node = node.next;
                index++;
            }
            ListNode nodeB = node.next;

            node = list2;
            while (node.next != null)
                node = node.next;

            nodeA.next = list2;
            node.next = nodeB;

            return list1;
        }
    }
}
