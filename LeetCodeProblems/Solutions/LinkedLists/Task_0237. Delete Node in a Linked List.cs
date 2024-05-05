namespace Solutions.LinkedLists
{
    internal class Task_0237
    {
        // #Linked List

        public void DeleteNode(ListNode node)
        {
            ListNode tmpNode = node;
            while (node.next != null)
            {
                node.val = node.next.val;
                (tmpNode, node) = (node, node.next);
            }
            tmpNode.next = null;

            // or another one
            // node.val = node.next.val;
            // node.next = node.next.next;
        }
    }
}
