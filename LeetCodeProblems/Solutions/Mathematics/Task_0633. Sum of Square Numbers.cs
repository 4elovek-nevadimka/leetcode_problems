namespace Solutions.Mathematics
{
    internal class Task_0633
    {
        // #Math #Two Pointers #Binary Search

        public bool JudgeSquareSum(int c)
        {
            int a = 0, b = (int)Math.Sqrt(c);
            while (a <= b)
            {
                long sum = (long)(a * a) + (long)(b * b);
                if (sum == c)
                    return true;
                else if (sum > c)
                    b--;
                else
                    a++;
            }
            return false;
        }
    }
}
