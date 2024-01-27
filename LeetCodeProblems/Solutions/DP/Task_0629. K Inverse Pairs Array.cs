namespace Solutions.DP
{
    class Task_0629
    {
		public int KInversePairs(int n, int k)
		{
			if (n == 0) return 0;

			if (k == 0) return 1;

			const int MOD = 1000000000 + 7;

			var dp = new int[n + 1, k + 1];

			for (var i = 1; i <= n; i++)
			{
				dp[i, 0] = 1;
				for (var j = 1; j <= k; j++)
				{
					long tmp = 0;
					for (var p = 0; p <= Math.Min(j, i - 1); p++)
					{
						tmp = (tmp + dp[i - 1, j - p]);
					}
					dp[i, j] = tmp % mod;
				}
			}

			return dp[n, k];
		}
	}
}
