using System.Text;

namespace Solutions.Strings
{
    internal class Task_1249
    {
        // #String #Stack

        public void Run()
        {
            Console.WriteLine(MinRemoveToMakeValid("lee(t(c)o)de)"));
            Console.WriteLine(MinRemoveToMakeValid("a)b(c)d"));
            Console.WriteLine(MinRemoveToMakeValid("))(("));
            Console.WriteLine(MinRemoveToMakeValid("())()((("));
        }

        public string MinRemoveToMakeValid(string s)
        {
            var stack = new Stack<int>();
            var goodString = new StringBuilder(s);

            for (var i = 0; i < goodString.Length; i++)
            {
                if (goodString[i] == '(')
                {
                    stack.Push(i);
                }
                else if (goodString[i] == ')')
                {
                    if (stack.Count == 0)
                    {
                        goodString[i] = '-';
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }

            while (stack.Count > 0)
            {
                goodString[stack.Pop()] = '-';
            }

            return goodString.ToString().Replace("-", "");
        }
    }
}
