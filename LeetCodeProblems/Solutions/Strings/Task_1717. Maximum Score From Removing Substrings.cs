namespace Solutions.Strings
{
    internal class Task_1717
    {
        // #String #Stack #Greedy

        public int MaximumGain(string s, int x, int y)
        {
            var primaryAward = (x < y) ? y : x;
            var secondaryAward = (x < y) ? x : y;
            var primaryC = (x < y) ? 'b' : 'a';
            var secondaryC = (x < y) ? 'a' : 'b';
            var primaryStack = new Stack<char>();
            var secondaryStack = new Stack<char>();

            var result = 0;

            foreach (char c in s)
            {
                if (c == primaryC)
                {
                    primaryStack.Push(c);
                }
                else if (c == secondaryC)
                {
                    if (primaryStack.Count > 0)
                    {
                        primaryStack.Pop();
                        result += primaryAward;
                    }
                    else
                    {
                        secondaryStack.Push(c);
                    }
                }
                else
                {
                    while (secondaryStack.Count > 0)
                    {
                        if (primaryStack.Count > 0)
                        {
                            primaryStack.Pop();
                            secondaryStack.Pop();
                            result += secondaryAward;
                        }
                        else
                            break;
                    }
                    primaryStack.Clear();
                    secondaryStack.Clear();
                }
            }

            while (secondaryStack.Count > 0)
            {
                if (primaryStack.Count > 0)
                {
                    primaryStack.Pop();
                    secondaryStack.Pop();
                    result += secondaryAward;
                }
                else
                    break;
            }

            return result;
        }
    }
}
