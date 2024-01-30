namespace Solutions.Arrays
{
    internal class Task_0150
    {
        public int EvalRPN(string[] tokens)
        {
            int a, b;
            var stack = new Stack<int>();
            foreach (var token in tokens)
            {
                switch (token)
                {
                    case "*":
                        stack.Push(stack.Pop() * stack.Pop());
                        break;
                    case "/":
                        a = stack.Pop(); b = stack.Pop();
                        stack.Push((int)Math.Truncate((double)(b / a)));
                        break;
                    case "+":
                        stack.Push(stack.Pop() + stack.Pop());
                        break;
                    case "-":
                        a = stack.Pop(); b = stack.Pop();
                        stack.Push(b - a);
                        break;
                    default:
                        if (int.TryParse(token, out int operand))
                            stack.Push(operand);
                        break;
                }
            }
            return stack.Pop();
        }
    }
}
