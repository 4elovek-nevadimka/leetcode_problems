namespace Solutions.BitManipulation
{
    internal class Task_1404
    {
        // #String #Bit Manipulation

        public int NumSteps(string s)
        {
            int steps = 0, carry = 0;
            for (int i = s.Length - 1; i > 0; i--)
            {
                if (s[i] - '0' + carry == 1)
                {
                    carry = 1;
                    // one step for subtracting 1 and one step for division
                    steps += 2; 
                }
                else
                {
                    // only one step for division
                    steps += 1;
                }
            }
            return steps + carry;
        }
    }
}
