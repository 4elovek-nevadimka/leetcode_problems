namespace Solutions.Arrays
{
    internal class Task_1287
    {
        // #Array
        public void Run()
        {
            var arr = new[] { 1, 2, 2, 6, 6, 6, 6, 7, 10 };
            Console.WriteLine(FindSpecialInteger(arr));
        }

        public int FindSpecialInteger(int[] arr)
        {
            int n = arr.Length;
            for (var i = 0; i < n; i++)
            {
                if (arr[i] == arr[i + n / 4])
                    return arr[i];
            }
            return -1;
        }
    }
}