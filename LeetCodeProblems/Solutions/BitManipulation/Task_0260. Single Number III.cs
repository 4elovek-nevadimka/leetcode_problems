namespace Solutions.BitManipulation
{
    internal class Task_0260
    {
        // #Array #Bit Manipulation

        public int[] SingleNumber(int[] nums)
        {
            var xorAll = 0;
            foreach (int num in nums)
                xorAll ^= num;

            xorAll &= -xorAll;

            var result = new int[2];
            foreach (int num in nums)
            {
                if ((num & xorAll) == 0)
                    result[0] ^= num;
                else
                    result[1] ^= num;
            }

            return result;
        }
    }
}
