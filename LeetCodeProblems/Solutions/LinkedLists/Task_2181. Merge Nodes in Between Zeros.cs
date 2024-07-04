namespace Solutions.LinkedLists
{
    internal class Task_2181
    {
        // #Linked List #Simulation

        public ListNode MergeNodes(ListNode head)
        {
            ListNode newHead = null, newNode = null, previousNode = null;
            int sum = 0;

            while (head != null)
            {
                if (head.val == 0)
                {
                    if (sum > 0)
                    {
                        newNode = new ListNode(sum);
                        if (newHead == null)
                        {
                            newHead = newNode;
                            previousNode = newNode;
                        }
                        else
                        {
                            previousNode.next = newNode;
                            previousNode = newNode;
                        }
                        sum = 0;
                    }
                }
                else
                {
                    sum += head.val;
                }
                head = head.next;
            }

            return newHead;
        }
    }
}
