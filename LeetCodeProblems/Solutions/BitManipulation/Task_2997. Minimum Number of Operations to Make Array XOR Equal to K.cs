namespace Solutions.BitManipulation
{
    internal class Task_2997
    {
        // #Array #Bit Manipulation

        public int MinOperations(int[] nums, int k)
        {
            var xor = 0;
            foreach (var num in nums)
                xor ^= num;

            if (xor == k)
                return 0;

            var counter = 0;
            var xorK = xor ^ k;
            while (xorK != 0)
            {
                counter += xorK & 1;
                xorK >>= 1;
            }

            return counter;
        }
    }
}
