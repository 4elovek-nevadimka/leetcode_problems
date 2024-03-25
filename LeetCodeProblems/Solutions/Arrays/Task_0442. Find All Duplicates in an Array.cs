namespace Solutions.Arrays
{
    internal class Task_0442
    {
        // #Array

        public void Run()
        {
            var duplicates = FindDuplicates([4, 3, 2, 7, 8, 2, 3, 1]);
        }

        public IList<int> FindDuplicates(int[] nums)
        {
            var duplicates = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1;
                if (nums[index] < 0)
                    duplicates.Add(index + 1);
                else
                    nums[index] = -nums[index];
            }
            return duplicates;
        }
    }
}
