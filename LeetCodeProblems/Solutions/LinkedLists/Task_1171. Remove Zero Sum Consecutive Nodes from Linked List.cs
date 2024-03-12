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
            var start = head;
            var dic = new Dictionary<int, ListNode>();
            while (head != null)
            {
                sum += head.val;
                if (sum == 0)
                {
                    dic.Clear();
                    start = head.next;
                }
                else
                {
                    if (dic.ContainsKey(sum))
                    {
                        dic[sum].next = head.next;
                        // dic[sum] = head; -- ??
                    }
                    else
                    {
                        dic.Add(sum, head);
                    }
                }
                head = head.next;
            }
            return start;
        }
    }
}
