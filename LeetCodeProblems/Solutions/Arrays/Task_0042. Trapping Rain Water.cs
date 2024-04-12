namespace Solutions.Arrays
{
    internal class Task_0042
    {
        // #Array #Two Pointers #Dynamic Programming #Stack #Monotonic Stack

        public int Trap(int[] height)
        {
            int water = 0;
            int left = 0, right = height.Length - 1;
            int leftMax = 0, rightMax = 0;
            while (left < right)
            {
                if (height[left] < height[right])
                {
                    if (height[left] >= leftMax)
                    {
                        leftMax = height[left];
                    }
                    else
                    {
                        water += leftMax - height[left];
                    }
                    left++;
                }
                else
                {
                    if (height[right] >= rightMax)
                    {
                        rightMax = height[right];
                    }
                    else
                    {
                        water += rightMax - height[right];
                    }
                    right--;
                }
            }

            return water;
        }
    }
}
