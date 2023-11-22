using System.Data;

namespace Solutions
{
    internal class Task_1424
    {
        public void Run()
        {

        }

        public int[] FindDiagonalOrder(IList<IList<int>> nums)
        {
            return Solution3(nums);
        }

        private int[] Solution1(IList<IList<int>> nums)
        {
            var diagList = new List<(int sum, int row, int val)>();

            int rowCounter = 0;
            foreach (var row in nums)
            {
                int colCounter = 0;
                foreach (var val in nums[rowCounter])
                {
                    diagList.Add((rowCounter + colCounter, rowCounter, val));
                    colCounter++;
                }
                rowCounter++;
            }

            return diagList
                .OrderBy(x => x.sum).ThenByDescending(x => x.row).Select(x => x.val).ToArray();
        }

        // Time Limit Exceeded
        private int[] Solution2(IList<IList<int>> nums)
        {
            int colCount = 0, rowCount = nums.Count;
            foreach (var row in nums)
            {
                colCount = Math.Max(colCount, row.Count);
            }

            var diagList = new List<int>();
            for (var line = 0; line < (rowCount + colCount - 1); line++)
            {
                // for line <= rowCount = 0, then increase
                var firstCol = Math.Max(0, line - rowCount);
                // for line <= rowCount = line + 1, then decrease
                var diagLength = Math.Min(line, Math.Min(colCount - firstCol, rowCount));

                for (int j = 0; j < diagLength; j++)
                {
                    var rowArrIndex = Math.Min(rowCount, line) - j - 1;
                    if (nums[rowArrIndex].Count > firstCol + j)
                    {
                        diagList.Add(nums[rowArrIndex][firstCol + j]);
                    }
                }
            }

            return diagList.ToArray();
        }

        private int[] Solution3(IList<IList<int>> nums)
        {
            var diagList = new List<int>();
            var queue = new Queue<(int row, int col)>();
            queue.Enqueue((0, 0));
            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                diagList.Add(nums[item.row][item.col]);
                if (item.col == 0 && item.row + 1 < nums.Count)
                {
                    queue.Enqueue((item.row + 1, item.col));
                }
                if (item.col + 1 < nums[item.row].Count)
                {
                    queue.Enqueue((item.row, item.col + 1));
                }
            }

            return diagList.ToArray();
        }
    }
}
