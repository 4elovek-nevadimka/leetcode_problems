namespace Solutions.LinkedLists
{
    internal class Task_2058
    {
        // #Linked List

        public int[] NodesBetweenCriticalPoints(ListNode head)
        {
            int index = 1, first = 0, previous = 0, min = int.MaxValue;
            ListNode previousNode = head;
            head = head.next;

            while (head != null)
            {
                if (head.next == null)
                    break;

                if ((head.val > previousNode.val && head.val > head.next.val) 
                    || (head.val < previousNode.val && head.val < head.next.val))
                {
                    if (first == 0)
                        first = previous = index;
                    else
                    {
                        min = Math.Min(min, index - previous);
                        previous = index;
                    }
                }
                previousNode = head;
                head = head.next;
                index++;
            }

            if (min == int.MaxValue)
                return [-1, -1];

            return [min, previous - first];
        }
    }
}
