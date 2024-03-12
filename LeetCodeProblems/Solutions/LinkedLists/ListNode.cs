namespace Solutions.LinkedLists
{
    internal class ListNode
    {
        public int val;
        
        public ListNode next;
        
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    internal static class ListNodeGenerator
    {
        internal static ListNode Generate(int[] nodesValues)
        {
            if (nodesValues == null || nodesValues.Length == 0)
                return null;

            ListNode empty = new(), current = empty;
            foreach (int nodeValue in nodesValues)
            {
                current.next = new ListNode(nodeValue);
                current = current.next;
            }

            return empty.next;
        }
    }
 
}
