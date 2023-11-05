namespace Solutions
{
    internal class Task_1535
    {
        public int GetWinner(int[] arr, int k)
        {
            int max = arr[0], currentK = 0;
            for (var i = 1; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                    currentK = 1;
                }
                else
                {
                    currentK++;
                }
                if (currentK == k) break;
            }
            return max;
        }
    }
}
