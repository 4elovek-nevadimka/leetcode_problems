namespace Solutions
{
    public class Task_0746
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            return Solution1(cost);
        }

        private int Solution1(int[] cost)
        {
            // dp solution
            var dp = new int[cost.Length + 1];

            // no cost to reach the first two steps
            (dp[0], dp[1]) = (0, 0);

            // find the minimum cost to reach each step
            for (var i = 2; i <= cost.Length; i++)
            {
                dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
            }

            // minimum of the last two steps
            return dp[cost.Length];
        }

        private int Solution2(int[] cost)
        {
            // in memory solution
            var n = cost.Length;
            
            for (var i = 2; i < n; i++)
            {
                cost[i] += Math.Min(cost[i - 1], cost[i - 2]);
            }
            return Math.Min(cost[n - 1], cost[n - 2]);
        }

        private int Solution3(int[] cost)
        {
            // 2 variables solution
            int a = cost[0], b = cost[1];

            for (var i = 2; i < cost.Length; i++)
            {
                var c = cost[i] + Math.Min(a, b);
                (a, b) = (b, c);
            }
            return Math.Min(a, b);
        }

        public void Run()
        {
            // expected 15
            // var cost = new[] { 10, 15, 20 };

            // expected 6
            var cost = new[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };

            var result = MinCostClimbingStairs(cost);
            Console.WriteLine(result);
        }
    }
}
