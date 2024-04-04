namespace Solutions.Strings
{
    internal class Task_1614
    {
        // #String #Stack

        public int MaxDepth(string s)
        {
            int depth = 0, maxDepth = 0;
            foreach (var c in s)
            {
                if (c == '(')
                {
                    depth++;
                    if (depth > maxDepth)
                        maxDepth = depth;
                }
                else if (c == ')')
                    depth--;
            }
            return maxDepth;
        }
    }
}
