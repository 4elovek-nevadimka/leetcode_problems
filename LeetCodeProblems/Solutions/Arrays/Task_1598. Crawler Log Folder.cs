namespace Solutions.Arrays
{
    internal class Task_1598
    {
        // #Array #String #Stack

        public int MinOperations(string[] logs)
        {
            int level = 0;
            foreach (var log in logs)
            {
                if (log == "./")
                    continue;

                if (log == "../")
                {
                    if (level > 0)
                        level--;
                }
                else
                    level++;
            }

            return level;
        }
    }
}
