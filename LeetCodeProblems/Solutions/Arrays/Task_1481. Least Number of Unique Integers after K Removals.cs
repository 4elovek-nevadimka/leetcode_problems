namespace Solutions.Arrays
{
    internal class Task_1481
    {
        // #Array #Hash Table #Greedy #Sorting #Counting

        public void Run()
        {
            // var arr = new[] { 4, 3, 1, 1, 3, 3, 2 };
            // var k = 3;
            //var arr = new[] { 1, 1 };
            //var k = 1;
            var arr = new[] { 2, 4, 1, 8, 3, 5, 1, 3 };
            var k = 3;
            Console.WriteLine(FindLeastNumOfUniqueInts(arr, k));
        }

        public int FindLeastNumOfUniqueInts(int[] arr, int k)
        {
            return Solution2(arr, k);
        }

        private int Solution1(int[] arr, int k)
        {
            var freq = new Dictionary<int, int>();
            foreach (var val in arr)
                if (!freq.ContainsKey(val))
                    freq[val] = 1;
                else
                    freq[val]++;

            var repeats = new Dictionary<int, int>();
            foreach (var val in freq.Keys)
                if (!repeats.ContainsKey(freq[val]))
                    repeats[freq[val]] = 1;
                else
                    repeats[freq[val]]++;

            var counter = 1;
            while (k > 0)
            {
                if (repeats.ContainsKey(counter))
                {
                    var exit = false;
                    while (repeats[counter] > 0)
                    {
                        if (k >= counter)
                        {
                            repeats[counter]--;
                            k -= counter;
                        }
                        else
                        {
                            exit = true;
                            break;
                        }
                    }
                    if (exit)
                        break;
                }
                counter++;
            }

            var answer = 0;
            foreach (var val in repeats.Keys)
                if (repeats[val] > 0)
                    answer += repeats[val];

            return answer;
        }

        private int Solution2(int[] arr, int k)
        {
            var freq = new Dictionary<int, int>();
            foreach (var val in arr)
                if (!freq.ContainsKey(val))
                    freq[val] = 1;
                else
                    freq[val]++;

            var repeats = new Dictionary<int, int>();
            foreach (var val in freq.Keys)
                if (!repeats.ContainsKey(freq[val]))
                    repeats[freq[val]] = 1;
                else
                    repeats[freq[val]]++;

            var counter = 1;
            while (k > 0)
            {
                if (repeats.ContainsKey(counter))
                {
                    var tmp = counter * repeats[counter];
                    if (tmp <= k)
                    {
                        repeats[counter] = 0;
                        k -= tmp;
                    }
                    else
                    {
                        if (k < counter)
                        {
                            break;
                        }
                        else
                        {
                            repeats[counter] -= k / counter;
                            break;
                        }
                    }
                }
                counter++;
            }

            var answer = 0;
            foreach (var val in repeats.Keys)
                if (repeats[val] > 0)
                    answer += repeats[val];

            return answer;
        }
    }
}
