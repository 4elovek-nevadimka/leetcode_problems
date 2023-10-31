namespace Solutions
{
    public class Task_1356
    {
        public void Run()
        {
            // var arr = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            var arr = new[] { 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 };
            var result = SortByBits(arr);
            Array.ForEach(result, Console.WriteLine);
        }

        public int[] SortByBits(int[] arr)
        {
            return Solution3(arr);
        }

        private int[] Solution3(int[] arr)
        {
            Array.Sort(arr, (a, b) => Compare(a, b));
            return arr;
        }

        private int Compare(int left, int right)
        {
            var res = CountSetBits(left) - CountSetBits(right);
            if (res != 0) return res;

            return left - right;
        }

        private int[] Solution2(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                int smallestBinValue = CountSetBits(arr[i]);
                int smallestValue = arr[i], smallestIndex = -1;
                for (var j = i + 1; j < arr.Length; j++)
                {
                    var currentBinValue = CountSetBits(arr[j]);
                    if (currentBinValue < smallestBinValue)
                    {
                        smallestBinValue = currentBinValue;
                        smallestValue = arr[j];
                        smallestIndex = j;
                    }
                    else if (currentBinValue == smallestBinValue)
                    {
                        if (arr[j] < smallestValue)
                        {
                            smallestValue = arr[j];
                            smallestIndex = j;
                        }
                    }
                }
                if (smallestIndex > -1)
                {
                    (arr[i], arr[smallestIndex]) = (arr[smallestIndex], arr[i]);
                }
            }
            return arr;
        }


        private int[] Solution1(int[] arr)
        {
            var pairs = new List<(int dec, int bin)>();
            foreach (var n in arr)
            {
                pairs.Add((n, CountSetBits(n)));
            }
            return pairs.OrderBy(x => x.bin).ThenBy(x => x.dec).Select(x => x.dec).ToArray();
        }

        private int CountSetBits(int n)
        {
            var setBits = 0;
            while (n > 0)
            {
                if ((n & 1) == 1)
                    setBits++;
                n >>= 1;
            }
            return setBits;
        }

        private int CountSetBits2(int n)
        {
            return Convert.ToString(n, 2).Count(x => x == '1');
        }
    }
}
