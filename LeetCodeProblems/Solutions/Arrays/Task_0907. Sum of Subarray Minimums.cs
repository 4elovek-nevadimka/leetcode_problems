namespace Solutions.Arrays
{
    internal class Task_0907
    {
        public void Run()
        {
            // var arr = new[] { 3, 1, 2, 4 };
            var arr = new[] { 11, 81, 94, 43, 3 };
            Console.WriteLine(SumSubarrayMins(arr));
        }

        public int SumSubarrayMins(int[] arr)
        {
            const int MOD = 1_000_000_007;

            var stack = new Stack<int>();
            var dp = new long[arr.Length + 1];
            dp[0] = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                while (stack.Count > 0 && arr[i] < arr[stack.Peek()])
                {
                    stack.Pop();
                }
                var j = stack.Count > 0 ? stack.Peek() : -1;
                dp[i + 1] = dp[j + 1] + (arr[i] * (i - j));
                stack.Push(i);
            }

            return (int)(dp.Sum() % MOD);
        }
    }
}
