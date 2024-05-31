namespace Solutions.BitManipulation
{
    internal class Task_1442
    {
        // #Array #Hash Table #Math #Bit Manipulation #Prefix Sum

        public int CountTriplets(int[] arr)
        {
            var n = arr.Length;
            var prefixXor = new int[n + 1];

            for (var i = 0; i < n; i++)
                prefixXor[i + 1] = prefixXor[i] ^ arr[i];

            var count = 0;
            for (var i = 0; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    if (prefixXor[i] == prefixXor[j + 1])
                        count += (j - i);
                }
            }

            return count;
        }
    }
}
