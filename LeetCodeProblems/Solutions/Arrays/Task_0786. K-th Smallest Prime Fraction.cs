namespace Solutions.Arrays
{
    internal class Task_0786
    {
        // #Array #Two Pointers #Binary Search #Sorting #Heap(Priority Queue)

        public int[] KthSmallestPrimeFraction(int[] arr, int k)
        {
            int n = arr.Length;
            int[] result = new int[2];
            double left = 0.0, right = 1.0;

            while (left < right)
            {
                int count = 0;
                double maxFraction = 0.0;
                double mid = left + (right - left) / 2;

                for (int i = 0, j = 1; i < n - 1; i++)
                {
                    while (j < n && arr[i] > mid * arr[j])
                        j++;

                    count += n - j;
                    if (j < n)
                    {
                        double fraction = (double)arr[i] / arr[j];
                        if (fraction > maxFraction)
                        {
                            maxFraction = fraction;
                            result[0] = arr[i];
                            result[1] = arr[j];
                        }
                    }
                }

                if (count == k)
                    break;
                else if (count < k)
                    left = mid;
                else
                    right = mid;
            }

            return result;
        }   
    }
}
