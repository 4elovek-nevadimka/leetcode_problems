namespace Solutions.Arrays
{
    internal class Task_0713
    {
        // #Array #Sliding Window

        public void Run()
        {
            Console.WriteLine(NumSubarrayProductLessThanK([10, 5, 2, 6], 100));
            Console.WriteLine(NumSubarrayProductLessThanK([1, 2, 3], 0));
            Console.WriteLine(NumSubarrayProductLessThanK([5, 2, 4, 5, 2, 5, 4, 3, 5, 2, 3, 4, 2, 4, 4, 5, 2, 2, 2, 5], 1));
        }

        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            return Solution2(nums, k);
        }

        private int Solution1(int[] nums, int k)
        {
            if (k == 0) return 0;

            var n = nums.Length;
            var buffer = new long[n];
            int subArrayLength = 0, productCount = 0;

            for (var i = 0; i < n; i++)
            {
                buffer[i] = nums[i];
                if (buffer[i] < k)
                    productCount++;
            }

            if (productCount > 0)
            {
                while (++subArrayLength < n)
                {
                    var previousCount = productCount;
                    for (var i = 0; i < n - subArrayLength; i++)
                    {
                        buffer[i] = buffer[i] * nums[i + subArrayLength];
                        if (buffer[i] < k)
                            productCount++;
                    }
                    if (previousCount == productCount)
                        break;
                }
            }

            return productCount;
        }

        private int Solution2(int[] nums, int k)
        {
            int left = 0, productCount = 0, curProduct = 1;
            for (var right = 0; right < nums.Length; right++)
            {
                curProduct *= nums[right];

                while (curProduct >= k && left <= right)
                {
                    curProduct /= nums[left++];
                }
                productCount += right - left + 1;

            }
            return productCount;
        }
    }
}
