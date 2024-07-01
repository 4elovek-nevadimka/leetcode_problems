namespace Solutions.Arrays
{
    internal class Task_1550
    {
        // #Array

        public bool ThreeConsecutiveOdds(int[] arr)
        {
            if (arr.Length < 3)
                return false;

            for (var i = 0; i < arr.Length - 2; i++)
            {
                if (int.IsOddInteger(arr[i]) 
                    && int.IsOddInteger(arr[i + 1]) 
                    && int.IsOddInteger(arr[i + 2]))
                    return true;
            }

            return false;
        }
    }
}
