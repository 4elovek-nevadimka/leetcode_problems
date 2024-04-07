namespace Solutions.Strings
{
    internal class Task_0678
    {
        // #String #Dynamic Programming #Stack #Greedy

        public bool CheckValidString(string s)
        {
            int opens = 0, closes = 0;
            foreach (char c in s)
            {
                if (c == '(')
                {
                    opens++;
                    closes++;
                }
                else if (c == ')')
                {
                    if (opens > 0)
                        opens--;
                    closes--;
                    if (closes < 0)
                        return false;
                }
                else
                {
                    if (opens > 0)
                        opens--;
                    closes++;
                }
            }

            return opens == 0;
        }
    }
}
