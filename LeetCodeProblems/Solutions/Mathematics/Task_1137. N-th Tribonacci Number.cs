namespace Solutions.Mathematics
{
    internal class Task_1137
    {
        // #Math #Dynamic Programming #Memoization

        public int Tribonacci(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1 || n == 2)
                return 1;

            var arr = new int[n + 1];
            arr[0] = 0; arr[1] = arr[2] = 1;
            for (var i = 3; i < n + 1; i++)
            {
                arr[i] = arr[i - 3] + arr[i - 2] + arr[i - 1];
            }

            return arr[n];
        }
    }
}
