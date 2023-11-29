namespace Solutions
{
    internal class Task_0191
    {
        public void Run()
        {
            uint n = 00000000000000000000000000001011;
            Console.WriteLine(HammingWeight(n));
        }

        public int HammingWeight(uint n)
        {
            return Solution2(n);
        }

        private int Solution1(uint n)
        {
            int setBits = 0;
            while (n > 0)
            {
                if ((n & 1) == 1)
                {
                    setBits++;
                }
                n = n >> 1;
            }
            return setBits;
        }

        private int Solution2(uint n)
        {
            int count = 0;
            while (n != 0)
            {
                count++;
                // clear the least significant set bit
                n &= (n - 1);
            }
            return count;
        }
    }
}
