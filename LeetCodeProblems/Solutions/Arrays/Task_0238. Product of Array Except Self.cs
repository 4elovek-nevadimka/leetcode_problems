namespace Solutions.Arrays
{
    internal class Task_0238
    {
        // #Array #Prefix Sum

        public int[] ProductExceptSelf(int[] nums)
        {
            var n = nums.Length;
            var result = new int[n];

            var leftProduct = 1;
            for (var i = 0; i < n; i++)
            {
                result[i] = leftProduct;
                leftProduct *= nums[i];
            }

            var rightProduct = 1;
            for (var i = n - 1; i >= 0; i--)
            {
                result[i] *= rightProduct;
                rightProduct *= nums[i];
            }

            return result;
        }
    }
}
