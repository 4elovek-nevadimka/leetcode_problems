namespace Solutions.Arrays
{
    internal class Task_0977
    {
        // #Array #Two Pointers #Sorting

        public int[] SortedSquares(int[] nums)
        {
            return Solution2(nums);
        }

        private int[] Solution1(int[] nums)
        {
            var result = new int[nums.Length];
            for (var i = 0; i < nums.Length; i++)
                result[i] = nums[i] * nums[i];

            Array.Sort(result);
            return result;
        }

        private int[] Solution2(int[] nums)
        {
            var maxNum = 0;
            // make positive and get max
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                    nums[i] = nums[i] * (-1);
                if (nums[i] > maxNum)
                    maxNum = nums[i];
            }

            var tmpArr = new int[maxNum + 1];
            for (var i = 0; i < nums.Length; i++)
                tmpArr[nums[i]]++;

            var index = 0;
            for (var i = 0; i < tmpArr.Length; i++)
                for (var j = 0; j < tmpArr[i]; j++)
                    nums[index++] = i * i;

            return nums;
        }

        private int[] Solution3(int[] nums)
        {
            var maxNum = 0;
            for (var i = 0; i < nums.Length; i++)
                if (Math.Abs(nums[i]) > maxNum)
                    maxNum = Math.Abs(nums[i]);

            var tmpArr = new int[maxNum + 1];
            for (var i = 0; i < nums.Length; i++)
                tmpArr[Math.Abs(nums[i])]++;

            var index = 0;
            for (var i = 0; i < tmpArr.Length; i++)
                for (var j = 0; j < tmpArr[i]; j++)
                    nums[index++] = i * i;

            return nums;
        }
    }
}