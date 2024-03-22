namespace Solutions.LinkedLists
{
    internal class Task_0234
    {
        // #Linked List #Two Pointers #Stack #Recursion

        public void Run()
        {
            Console.WriteLine(IsPalindrome(ListNodeGenerator.Generate([1, 2])));
            Console.WriteLine(IsPalindrome(ListNodeGenerator.Generate([1, 2, 2, 1])));
            Console.WriteLine(IsPalindrome(ListNodeGenerator.Generate([1, 2, 3, 2, 1])));
            Console.WriteLine(IsPalindrome(ListNodeGenerator.Generate([1, 6, 1, 1])));
        }

        public bool IsPalindrome(ListNode head)
        {
            return Solution2(head);
        }

        private bool Solution1(ListNode head)
        {
            var stack = new Stack<int>();
            ListNode fast = head, slow = head;
            while (fast.next != null && fast.next.next != null)
            {
                stack.Push(slow.val);
                fast = fast.next.next;
                slow = slow.next;
            }
            stack.Push(slow.val);
            if (fast.next != null)
                slow = slow.next;

            while (stack.Count > 0 && slow != null)
            {
                if (stack.Pop() != slow.val)
                    return false;
                slow = slow.next;
            }
            return stack.Count == 0 && slow == null;
        }

        private bool Solution2(ListNode head)
        {
            ListNode fast = head, slow = head;
            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            if (fast.next != null)
            {
                var tmp = slow;
                slow = slow.next;
                tmp.next = null;
            }

            slow = ReverseList(slow);
            while (slow != null && head != null)
            {
                if (slow.val != head.val)
                    return false;
                slow = slow.next;
                head = head.next;
            }
            return slow == null && head == null;
        }

        private ListNode ReverseList(ListNode head)
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
