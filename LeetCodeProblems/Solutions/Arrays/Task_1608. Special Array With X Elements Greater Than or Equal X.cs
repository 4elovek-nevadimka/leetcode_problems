namespace Solutions.Arrays
{
    internal class Task_1608
    {
        // #Array #Binary Search #Sorting

        public void Run()
        {
            // Console.WriteLine(SpecialArray([3, 5]));
            // Console.WriteLine(SpecialArray([0, 0]));
            // Console.WriteLine(SpecialArray([0, 2, 3, 0, 3]));
            // Console.WriteLine(SpecialArray([0, 4, 2, 0, 4]));
            // Console.WriteLine(SpecialArray([0, 4, 4, 0, 4]));

            // Console.WriteLine(SpecialArray([0, 1, 2, 3, 40, 50, 60, 70, 80]));
            // Console.WriteLine(SpecialArray([3, 6, 7, 7, 0]));
            Console.WriteLine(SpecialArray([0]));
        }

        public int SpecialArray(int[] nums)
        {
            // linear sorting
            var arr = new int[nums.Max() + 1];
            foreach (var num in nums)
                arr[num]++;

            var n = nums.Length;
            var newNums = new List<int>(n);
            for (var i = 0; i < arr.Length; i++)
                for (var j = 0; j < arr[i]; j++)
                    newNums.Add(i);

            nums = [.. newNums];

            if (nums[0] >= n)
                return n;

            var x = BinarySearch(nums);
            if (x == 0)
                return -1;

            return nums[^x] >= x ? x : -1;
        }

        private int BinarySearch(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                var mid = left + (right - left) / 2;

                if (nums.Count(num => num >= mid) <= mid)
                    right = mid;
                else
                    left = mid + 1;
            }

            return left;
        }
    }
}
