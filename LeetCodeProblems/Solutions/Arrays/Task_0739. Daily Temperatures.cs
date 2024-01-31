namespace Solutions.Arrays
{
    internal class Task_0739
    {
        // #Array #Stack #Monotonic Stack

        public int[] DailyTemperatures(int[] temperatures)
        {
            var n = temperatures.Length;
            var answer = new int[n];

            var stack = new Stack<int>();
            stack.Push(0);
            for (var i = 1; i < n; i++)
            {
                while (stack.Count > 0 &&
                    temperatures[stack.Peek()] < temperatures[i])
                {
                    var index = stack.Pop();
                    answer[index] = i - index;
                }
                stack.Push(i);
            }
            while (stack.Count > 0)
                answer[stack.Pop()] = 0;

            return answer;
        }
    }
}
