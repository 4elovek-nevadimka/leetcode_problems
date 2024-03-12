namespace Solutions.LinkedLists
{
    internal class Task_1171
    {
        // #Linked List #Hash Table

        public void Run()
        {
            var head = ListNodeGenerator.Generate([1, 3, 2, -3, -2, 5, 5, -5, 1]);
            var current = RemoveZeroSumSublists(head);
            while (current != null)
            {
                Console.Write(current.val + " -> ");
                current = current.next;
            }
            Console.WriteLine("null");
        }

        public ListNode RemoveZeroSumSublists(ListNode head)
        {
            var sum = 0;
            var start = new ListNode(0, head);
            var dic = new Dictionary<int, ListNode>();

            head = start;
            while (head != null)
            {
                sum += head.val;
                dic[sum] = head;
                head = head.next;
            }

            sum = 0;
            head = start;
            while (head != null)
            {
                sum += head.val;
                head.next = dic[sum].next;
                head = head.next;
            }

            return start.next;
        }
    }
}
