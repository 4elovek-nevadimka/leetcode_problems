namespace Solutions.Mathematics
{
    internal class Task_0231
    {
        // #Math #Bit Manipulation #Recursion

        public void Run()
        {
            Console.WriteLine(IsPowerOfTwo(536870912));
        }

        public bool IsPowerOfTwo(int n)
        {
            return Solution3(n);
        }

        private bool Solution1(int n)
        {
            // doesn't work for 536870912
            return Math.Log(n, 2) % 1 == 0;
        }

        private bool Solution2(int n)
        {
            return
                n >= 1 && Math.Pow(2, Math.Truncate(Math.Log(n, 2))) == n;
        }

        private bool Solution3(int n)
        {
            return n >= 1 && (n & (n - 1)) == 0;
        }
    }
}
