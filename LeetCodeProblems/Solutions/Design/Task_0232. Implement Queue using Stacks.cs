namespace Solutions.Design
{
    internal class Task_0232
    {
    }

    public class MyQueue
    {
        private readonly Stack<int> one, two;

        public MyQueue()
        {
            one = new Stack<int>();
            two = new Stack<int>();
        }

        public void Push(int x)
        {
            one.Push(x);
        }

        public int Pop()
        {
            if (two.Count == 0)
            {
                while (one.Count > 0)
                {
                    two.Push(one.Pop());
                }
            }
            return two.Pop();
        }

        public int Peek()
        {
            if (two.Count == 0)
            {
                while (one.Count > 0)
                {
                    two.Push(one.Pop());
                }
            }
            return two.Peek();
        }

        public bool Empty()
        {
            return Math.Max(one.Count, two.Count) == 0;
        }
    }
}
