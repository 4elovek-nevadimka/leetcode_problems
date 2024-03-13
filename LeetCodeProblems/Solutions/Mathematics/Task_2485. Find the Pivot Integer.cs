namespace Solutions.Mathematics
{
    internal class Task_2485
    {
        // #Math #Prefix Sum

        public int PivotInteger(int n)
        {
            return Solution1(n);
        }

        private int Solution1(int n)
        {
            var rightSum = 0;
            var leftSum = n * (n + 1) / 2;
            for (var i = n; i > 0; i--)
            {
                rightSum += i;
                if (rightSum == leftSum)
                    return i;
                else
                    leftSum -= i;
                if (rightSum > leftSum)
                    break;
            }
            return -1;
        }

        private int Solution2(int n)
        {
            var sum = n * (n + 1) / 2;
            var pivot = (int)Math.Sqrt(sum);
            return Math.Pow(pivot, 2) == sum ? pivot : -1;
        }
    }
}
