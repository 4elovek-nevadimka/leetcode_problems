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

            Console.WriteLine(SpecialArray([0, 1, 2, 3, 40, 50, 60, 70, 80]));
            Console.WriteLine(SpecialArray([3, 6, 7, 7, 0]));
        }

        public int SpecialArray(int[] nums)
        {
            Array.Sort(nums);

            var n = nums.Length;
            if (nums[0] >= n)
                return n;

            for (var i = 0; i < n; i++)
                if (nums[i] == n - i || nums[i] > n - i)
                    if (i > 0 && nums[i - 1] != n - i)
                        return n - i;
                    else
                        break;

            return -1;
        }

        private int BinarySearch(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                var mid = (left + right) / 2;
                if (nums[mid] == right - mid + 1)
                {
                    return nums[mid];
                }
                else
                {
                    if (nums[mid] < right - mid + 1)
                    {
                        return -1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
            }

            return -1;
        }
    }
}
