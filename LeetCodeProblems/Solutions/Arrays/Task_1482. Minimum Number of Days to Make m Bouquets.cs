namespace Solutions.Arrays
{
    internal class Task_1482
    {
        // #Array #Binary Search

        public int MinDays(int[] bloomDay, int m, int k)
        {
            if ((long)k * m > bloomDay.Length)
                return -1;

            int left = bloomDay.Min(), right = bloomDay.Max();
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (CanMakeAllBouquets(bloomDay, m, k, mid))
                    right = mid;
                else
                    left = mid + 1;
            }

            return left;
        }

        private bool CanMakeAllBouquets(int[] bloomDay, int m, int k, int day)
        {
            int tmpK = 0;
            foreach (int bDay in bloomDay)
            {
                if (bDay <= day)
                {
                    if (++tmpK == k)
                    {
                        m--;
                        tmpK = 0;
                        if (m == 0)
                            return true;
                    }
                }
                else
                    tmpK = 0;
            }
            return false;
        }
    }
}
