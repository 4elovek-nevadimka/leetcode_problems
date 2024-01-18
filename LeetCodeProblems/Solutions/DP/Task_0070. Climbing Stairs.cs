namespace Solutions.DP
{
    internal class Task_0070
    {
        // #Math #Dynamic Programming #Memoization

        public int ClimbStairs(int n)
        {
            return Solution2(n);
        }

        private int Solution1(int n)
        {
            // Time Limit Exceeded
            if (n == 1)
                return 1;
            if (n == 2)
                return 2;
            return ClimbStairs(n - 1) + ClimbStairs(n - 2);
        }

        private int Solution2(int n)
        {
            var dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 2;
            for (var i = 2; i < n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n - 1];
        }

        private int Solution3(int n)
        {
            int a = 0, b = 1;
            for (var i = 0; i < n; i++)
            {
                (a, b) = (b, a + b);
            }
            return b;
        }
    }
}
