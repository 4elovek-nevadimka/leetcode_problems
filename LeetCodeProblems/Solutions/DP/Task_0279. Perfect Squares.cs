namespace Solutions.DP
{
    internal class Task_0279
    {
        // #Math #Dynamic Programming #Breadth-First Search

        public void Run()
        {
            Console.WriteLine(NumSquares(8609));
        }

        public int NumSquares(int n)
        {
            return Solution2(n);
        }

        private int Solution1(int n)
        {
            var dp = new int[n + 1];
            dp[0] = 0;

            for (int i = 1; i <= n; i++)
            {
                dp[i] = i;
                for (int j = 1; j * j <= i; j++)
                {
                    int square = j * j;
                    dp[i] = Math.Min(dp[i], 1 + dp[i - square]);
                }
            }
            return dp[n];
        }

        private int Solution2(int n)
        {
            var sqrt = (int)Math.Sqrt(n);

            // Perfect square
            if (sqrt * sqrt == n) return 1;

            // 3-Square Theorem: 4^a (8b + 7)
            while (n % 4 == 0) 
                n /= 4;

            if (n % 8 == 7)
                return 4;

            // Sum of two perfect squares
            for (int i = 1; i * i <= n; i++)
            {
                var square = i * i;
                var one = (int)Math.Sqrt(n - square);

                if (one * one == n - square)
                    return 2;
            }

            return 3;
        }
    }
}
