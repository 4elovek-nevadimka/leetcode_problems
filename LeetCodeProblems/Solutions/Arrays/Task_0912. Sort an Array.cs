namespace Solutions.Arrays
{
    internal class Task_0912
    {
        // #Array #Divide and Conquer #Sorting #Heap(Priority Queue) #Merge Sort #Bucket Sort #Radix Sort #Counting Sort

        public int[] SortArray(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
                return nums;

            int[] tempArray = new int[nums.Length];
            MergeSort(nums, tempArray, 0, nums.Length - 1);
            return nums;
        }

        private void MergeSort(int[] nums, int[] tempArray, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(nums, tempArray, left, mid);
                MergeSort(nums, tempArray, mid + 1, right);
                Merge(nums, tempArray, left, mid, right);
            }
        }

        private void Merge(int[] nums, int[] tempArray, int left, int mid, int right)
        {
            for (int i = left; i <= right; i++)
                tempArray[i] = nums[i];

            int leftIndex = left;
            int rightIndex = mid + 1;
            int current = left;

            while (leftIndex <= mid && rightIndex <= right)
            {
                if (tempArray[leftIndex] <= tempArray[rightIndex])
                {
                    nums[current] = tempArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    nums[current] = tempArray[rightIndex];
                    rightIndex++;
                }
                current++;
            }

            while (leftIndex <= mid)
            {
                nums[current] = tempArray[leftIndex];
                leftIndex++;
                current++;
            }
        }
    }
}
