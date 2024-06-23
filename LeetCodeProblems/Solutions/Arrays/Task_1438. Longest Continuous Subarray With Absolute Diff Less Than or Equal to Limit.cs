namespace Solutions.Arrays
{
    internal class Task_1438
    {
        // #Array #Queue #Sliding Window #Heap(Priority Queue) #Ordered Set #Monotonic Queue

        public int LongestSubarray(int[] nums, int limit)
        {
            int left = 0, result = 0;
            LinkedList<int> maxDeque = new (), minDeque = new();

            for (int right = 0; right < nums.Length; right++)
            {
                while (maxDeque.Count > 0 && nums[maxDeque.Last.Value] <= nums[right])
                {
                    maxDeque.RemoveLast();
                }
                while (minDeque.Count > 0 && nums[minDeque.Last.Value] >= nums[right])
                {
                    minDeque.RemoveLast();
                }

                maxDeque.AddLast(right);
                minDeque.AddLast(right);

                while (nums[maxDeque.First.Value] - nums[minDeque.First.Value] > limit)
                {
                    if (maxDeque.First.Value == left)
                    {
                        maxDeque.RemoveFirst();
                    }
                    if (minDeque.First.Value == left)
                    {
                        minDeque.RemoveFirst();
                    }
                    left++;
                }

                result = Math.Max(result, right - left + 1);
            }

            return result;
        }
    }
}
