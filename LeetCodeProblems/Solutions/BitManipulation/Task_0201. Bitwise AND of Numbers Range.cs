namespace Solutions.BitManipulation
{
    // #Bit Manipulation

    internal class Task_0201
    {
        public int RangeBitwiseAnd(int left, int right)
        {
            while (left < right)
                right &= (right - 1);

            return left & right;
        }
    }
}
