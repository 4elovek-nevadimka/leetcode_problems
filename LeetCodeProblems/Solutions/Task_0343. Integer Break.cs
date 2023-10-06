namespace Solutions
{
    public class Task_0343
    {
        public int IntegerBreak(int n)
        {
            return Solution2(n);
        }

        public void Run()
        {
            // expected 1458
            // var n = 20;

            // expected 54
            var n = 11;

            var result = IntegerBreak(n);
            Console.WriteLine(result);
        }

        private int Solution1(int n)
        {
            if (n < 4)
                return n - 1;
            var dp = new int[n + 2];
            dp[1] = 1; dp[2] = 1; dp[3] = 2;
            for (var i = 4; i <= n + 1; i++)
            {
                if (i % 3 == 0)
                {
                    dp[i] = dp[i - 1] + dp[i - 4];
                }
                else
                {
                    dp[i] = dp[i - 1] + dp[i - 3];
                }
            }
            return dp[^1];
        }

        private int Solution2(int n)
        {
            if (n == 2) return 1;
            if (n == 3) return 2;

            var threeAppearsTimes = n / 3;
            var modulo = n % 3;

            if (modulo == 0)
            {
                return (int)Math.Pow(3, threeAppearsTimes);
            }
            else if (modulo == 1)
            {
                return (int)Math.Pow(3, threeAppearsTimes - modulo) * 4;
            }
            else
            {
                return (int)Math.Pow(3, threeAppearsTimes) * modulo;
            }
        }
    }
}
