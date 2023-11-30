
namespace Solutions
{
    internal class Task_1611
    {
        public int MinimumOneBitOperations(int n)
        {
            if (n == 0) return 0;
            return n ^ MinimumOneBitOperations(n >> 1);
        }
    }
}
