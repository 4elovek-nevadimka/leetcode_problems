namespace Solutions.LinkedLists
{
    internal class Task_2816
    {
        // #Linked List #Math #Stack

        public ListNode DoubleIt(ListNode head)
        {
            return Solution1(head);
        }

        private ListNode Solution1(ListNode head)
        {
            var stack = new Stack<ListNode>();
            var node = head;
            while (node != null)
            {
                stack.Push(node);
                node = node.next;
            }

            var carryOver = false;
            while (stack.Count > 0)
            {
                node = stack.Pop();
                if (node.val < 5)
                {
                    node.val = node.val * 2 + (carryOver ? 1 : 0);
                    carryOver = false;
                }
                else
                {
                    node.val = node.val * 2 % 10 + (carryOver ? 1 : 0);
                    carryOver = true;
                }
            }

            return carryOver ? new ListNode(1, head) : head;
        }

        private ListNode Solution2(ListNode head)
        {
            ListNode zeroHead = new(0, head), prevNode = zeroHead;
            while (head != null)
            {
                int val = head.val * 2;
                if (val >= 10)
                    prevNode.val++;
                head.val = val % 10;
                prevNode = head;
                head = head.next;
            }
            return zeroHead.val > 0 ? zeroHead : zeroHead.next;
        }
    }
}
