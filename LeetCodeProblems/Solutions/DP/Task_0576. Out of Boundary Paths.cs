namespace Solutions.DP
{
    internal class Task_0576
    {
        // #Dynamic Programming

        public void Run()
        {
            Console.WriteLine(FindPaths(2, 2, 2, 0, 0));
            // Console.WriteLine(FindPaths(1, 3, 3, 0, 1));
            // Console.WriteLine(FindPaths(8, 4, 10, 5, 0));
            // Console.WriteLine(FindPaths(8, 50, 23, 5, 26));
        }

        private const int MOD = 1000000000 + 7;

        public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
        {
            if (maxMove == 0)
                return 0;

            var dp = new int[m, n, maxMove + 1];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k <= maxMove; k++)
                        dp[i, j, k] = -1;

            return Traverse(m, n, maxMove, startRow, startColumn, dp);
        }

        private int Traverse(int m, int n, int maxMove, int iRow, int iCol, int[,,] dp)
        {
            if (iRow < 0 || iRow >= m || iCol < 0 || iCol >= n) 
                return 1;

            if (maxMove == 0) 
                return 0;

            if (dp[iRow, iCol, maxMove] != -1)
                return dp[iRow, iCol, maxMove];

            long longVal = 0;
            longVal += Traverse(m, n, maxMove - 1, iRow + 1, iCol, dp);
            longVal += Traverse(m, n, maxMove - 1, iRow, iCol - 1, dp);
            longVal += Traverse(m, n, maxMove - 1, iRow - 1, iCol, dp);
            longVal += Traverse(m, n, maxMove - 1, iRow, iCol + 1, dp);

            int intVal = (int)(longVal % MOD);
            dp[iRow, iCol, maxMove] = intVal;

            return intVal;
        }
    }
}
