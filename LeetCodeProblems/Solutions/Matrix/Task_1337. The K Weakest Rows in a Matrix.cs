namespace Solutions.Matrix
{
    internal class Task_1337
    {
        // #Array #Binary Search #Sorting #Heap(Priority Queue) #Matrix

        public void Run()
        {
            var mat = new[] { 
                new[] { 1, 0, 0, 0 }, 
                new[] { 1, 1, 1, 1 }, 
                new[] { 1, 0, 0, 0 }, 
                new[] { 1, 0, 0, 0 } };
            var k = 2;
            var result = KWeakestRows(mat, k);
            Array.ForEach(result, Console.WriteLine);
        }

        public int[] KWeakestRows(int[][] mat, int k)
        {
            return Solution4(mat, k);
        }

        private int[] Solution1(int[][] mat, int k)
        {
            var rows = mat.Length;
            var cols = mat[0].Length;

            var rankedList = new List<(int Index, int Rank)>();

            for (var i = 0; i < rows; i++)
            {
                var rank = Array.IndexOf(mat[i], 0);
                rankedList.Add((i, rank < 0 ? cols : rank));
            }

            rankedList.Sort((a, b) =>
            {
                if (a.Rank != b.Rank)
                {
                    return a.Rank.CompareTo(b.Rank);
                }
                else
                {
                    return a.Index.CompareTo(b.Index);
                }
            });

            var result = new int[k];
            for (int i = 0; i < k; i++)
            {
                result[i] = rankedList[i].Index;
            }

            return result;
        }

        private int[] Solution2(int[][] mat, int k)
        {
            return mat
                .Select((row, i) => new { Soldiers = row.Sum(), Index = i })
                .OrderBy(row => row.Soldiers)
                .ThenBy(row => row.Index)
                .Take(k)
                .Select(row => row.Index)
                .ToArray();
        }

        private int[] Solution3(int[][] mat, int k)
        {
            var dict = new SortedDictionary<(int Soldiers, int Index), int>();
            for (int i = 0; i < mat.Length; ++i)
            {
                dict[(Soldiers: GetSoldiers(mat[i]), Index: i)] = i;
            }
            return dict.Values.Take(k).ToArray();
        }

        private int GetSoldiers(int[] row)
        {
            int left = 0, right = row.Length;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (row[mid] == 1)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return left;
        }

        private int[] Solution4(int[][] mat, int k)
        {
            var queue = new PriorityQueue<int, int>();
            for (var i = 0; i < mat.Length; i++)
            {
                var soldiers = 0;
                for (var j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] == 1)
                        soldiers++;
                }
                queue.Enqueue(i, soldiers);
            }

            var weakest = new int[k];
            for (var i = 0; i < k; i++)
            {
                // wtf
                weakest[i] = queue.Dequeue();
            }

            return weakest;
        }
    }
}
