using System;

namespace Solutions.Arrays
{
    internal class Task_2966
    {
        public void Run()
        {
            var nums = new int[] { 1, 3, 4, 8, 7, 9, 3, 5, 1 };
            var k = 2;
            Console.WriteLine(DivideArray(nums, k));
        }

        public int[][] DivideArray(int[] nums, int k)
        {
            return Solution3(nums, k);
        }

        private int[][] Solution1(int[] nums, int k)
        {
            Array.Sort(nums);

            var subArraysCounter = 0;
            var subArray = new List<int>();
            var result = new int[nums.Length / 3][];
            foreach (var num in nums)
            {
                subArray.Add(num);
                if (subArray.Count == 3)
                {
                    if (subArray[2] - subArray[1] > k
                        || subArray[1] - subArray[0] > k
                        || subArray[2] - subArray[0] > k)
                    {
                        return Array.Empty<int[]>();
                    }
                    result[subArraysCounter] = subArray.ToArray();
                    subArraysCounter++;
                    subArray.Clear();
                }
            }

            return result;
        }

        private int[][] Solution2(int[] nums, int k)
        {
            var sortedArray = new int[nums.Max() + 1];
            foreach (var num in nums)
            {
                sortedArray[num]++;
            }

            var subArraysCounter = 0;
            var subArray = new List<int>();
            var result = new int[nums.Length / 3][];
            for (var i = 0; i < sortedArray.Length; i++)
            {
                for (var j = 0; j < sortedArray[i]; j++)
                {
                    subArray.Add(i);
                    if (subArray.Count == 3)
                    {
                        if (subArray[2] - subArray[1] > k
                            || subArray[1] - subArray[0] > k
                            || subArray[2] - subArray[0] > k)
                        {
                            return Array.Empty<int[]>();
                        }
                        result[subArraysCounter] = subArray.ToArray();
                        subArraysCounter++;
                        subArray.Clear();
                    }
                }
            }
            return result;
        }

        private int[][] Solution3(int[] nums, int k)
        {
            var sortedArray = new int[nums.Max() + 1];
            foreach (var num in nums)
            {
                sortedArray[num]++;
            }

            var subArrayIndex = 0;
            var subArraysCounter = 0;
            var result = new int[nums.Length / 3][];
            for (var i = 0; i < sortedArray.Length; i++)
            {
                for (var j = 0; j < sortedArray[i]; j++)
                {
                    if (subArrayIndex == 0)
                    {
                        result[subArraysCounter] = new int[3];
                    }
                    result[subArraysCounter][subArrayIndex] = i;

                    if (subArrayIndex == 2)
                    {
                        if (result[subArraysCounter][2] - result[subArraysCounter][1] > k
                            || result[subArraysCounter][1] - result[subArraysCounter][0] > k
                            || result[subArraysCounter][2] - result[subArraysCounter][0] > k)
                        {
                            return Array.Empty<int[]>();
                        }
                        subArraysCounter++;
                        subArrayIndex = -1;
                    }
                    subArrayIndex++;
                }
            }
            return result;
        }
    }
}
