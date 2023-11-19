namespace Solutions
{
    internal class Task_1887
    {
        public void Run()
        {
            var nums = new[] { 1, 1, 2, 2, 3 };
            // var nums = new[] { 1, 2, 3, 4, 5, 5, 5 };

            Console.WriteLine(ReductionOperations(nums));
        }

        public int ReductionOperations(int[] nums)
        {
            return Solution1(nums);
        }

        private int Solution1(int[] nums)
        {
            Array.Sort(nums);

            int startingIndex = 0, stepsToSmallest = 0,
                currentNum = 0, currentNumCounter = 0, totalOperations = 0;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[0] < nums[i])
                {
                    startingIndex = i + 1;
                    stepsToSmallest = 1;
                    currentNum = nums[i];
                    currentNumCounter = 1;
                    break;
                }
            }
            // All elements in nums are already equal.
            if (startingIndex == 0) return 0;
            
            for (var i = startingIndex; i < nums.Length; i++)
            {
                if (currentNum != nums[i])
                {
                    totalOperations += stepsToSmallest * currentNumCounter;
                    currentNum = nums[i];
                    currentNumCounter = 1;
                    stepsToSmallest++;
                }
                else
                {
                    currentNumCounter++;
                }
            }
            totalOperations += stepsToSmallest * currentNumCounter;

            return totalOperations;
        }
    }
}
