namespace Solutions
{
    internal class Task_0935
    {
        private const int MOD = 1000000000 + 7;

        public void Run()
        {
            Console.WriteLine(KnightDialer(3131));
        }

        public int KnightDialer(int n)
        {
            return Solution2(n);
        }

        #region Solution1

        private int[][] _memo;

        private int[][] _steps = new[] {
            new[] {4, 6},
            new[] { 6, 8 },
            new[] { 7, 9 },
            new[] { 4, 8 },
            new[] { 3, 9, 0 },
            Array.Empty<int>(),
            new[] { 1, 7, 0 },
            new[] { 2, 6 },
            new[] { 1, 3 },
            new[] { 2, 4 }
        };

        private int Solution1(int n)
        {
            _memo = new int[n + 1][];
            var result = 0;
            for (int square = 0; square < 10; square++)
            {
                result = (result + dp(n - 1, square)) % MOD;
            }

            return result;
        }

        private int dp(int remain, int cell)
        {
            if (remain == 0)
            {
                return 1;
            }

            if (_memo[remain] == null)
            {
                _memo[remain] = new int[10];
            }

            if (_memo[remain][cell] != 0)
            {
                return _memo[remain][cell];
            }

            var result = 0;
            foreach (var nextCell in _steps[cell])
            {
                result = (result + dp(remain - 1, nextCell)) % MOD;
            }

            _memo[remain][cell] = result;
            return result;
        }

        #endregion

        #region Solution2

        public int Solution2(int n)
        {
            if (n == 1)
            {
                return 10;
            }

            int a = 4, b = 2, c = 2, d = 1;
            for (int i = 0; i < n - 1; i++)
            {
                int tmpA, tmpB, tmpC, tmpD;
                (tmpA, tmpB, tmpC, tmpD) = (a, b, c, d);

                a = (2 * tmpB % MOD + 2 * tmpC % MOD) % MOD;
                b = tmpA;
                c = (tmpA + 2 * tmpD % MOD) % MOD;
                d = tmpC;
            }

            return (((((a + b) % MOD) + c) % MOD) + d) % MOD;
        }

        #endregion

    }
}
