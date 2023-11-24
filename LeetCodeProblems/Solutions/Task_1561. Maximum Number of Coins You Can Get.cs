namespace Solutions
{
    internal class Task_1561
    {
        public int MaxCoins(int[] piles)
        {
            return Solution2(piles);
        }

        private int Solution1(int[] piles)
        {
            Array.Sort(piles);
            var loopsCount = piles.Length / 3;
            int loopCounter = 0, maxCoinsSum = 0;
            while (loopCounter < loopsCount)
            {
                maxCoinsSum += piles[^((loopCounter + 1) * 2)];
                loopCounter++;
            }

            return maxCoinsSum;
        }

        private int Solution2(int[] piles)
        {
            Array.Sort(piles);
            int maxCoinsSum = 0;
            int left = 0, right = piles.Length - 1;
            while (left < right)
            {
                maxCoinsSum += piles[right - 1];
                right -= 2;
                left++;
            }
            return maxCoinsSum;
        }
    }
}
