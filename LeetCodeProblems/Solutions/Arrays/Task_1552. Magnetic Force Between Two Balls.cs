namespace Solutions.Arrays
{
    internal class Task_1552
    {
        // #Array #Binary Search #Sorting

        public int MaxDistance(int[] position, int m)
        {
            Array.Sort(position);

            int left = 1, right = position[^1] - position[0];
            while (left < right)
            {
                int mid = left + (right - left + 1) / 2;
                if (CanPlaceBalls(position, m, mid))
                    left = mid;
                else
                    right = mid - 1;
            }

            return left;
        }

        private bool CanPlaceBalls(int[] position, int m, int minDist)
        {
            int count = 1;
            int lastPosition = position[0];

            for (int i = 1; i < position.Length; i++)
            {
                if (position[i] - lastPosition >= minDist)
                {
                    count++;
                    lastPosition = position[i];
                    if (count == m)
                        return true;
                }
            }

            return false;
        }
    }
}
