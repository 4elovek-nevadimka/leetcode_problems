using System.Text;

namespace Solutions.Strings
{
    internal class Task_0791
    {
        // #Hash Table #String #Sorting

        public void Run()
        {
            Console.WriteLine(CustomSortString("cba", "abcd"));
        }

        public string CustomSortString(string order, string s)
        {
            return Solution3(order, s);
        }

        private string Solution1(string order, string s)
        {
            var priorityDic = new Dictionary<char, int>();
            for (var i = 0; i < order.Length; i++)
                priorityDic[order[i]] = i;

            var priorityArr = new List<char>[order.Length + 1];
            foreach (var c in s)
            {
                var index =
                    priorityDic.ContainsKey(c) ? priorityDic[c] : order.Length;
                if (priorityArr[index] == null)
                    priorityArr[index] = [c];
                else
                    priorityArr[index].Add(c);
            }

            var sb = new StringBuilder();
            foreach (var list in priorityArr)
                sb.Append(list?.ToArray());

            return sb.ToString();
        }

        private string Solution2(string order, string s)
        {
            var priorityDic = new Dictionary<char, int>();
            for (var i = 0; i < order.Length; i++)
                priorityDic[order[i]] = i;

            var priorityArr = new int[order.Length];
            var otherChars = new StringBuilder();
            foreach (var c in s)
            {
                if (priorityDic.ContainsKey(c))
                    priorityArr[priorityDic[c]]++;
                else
                    otherChars.Append(c);
            }

            var sb = new StringBuilder();
            for (var i = 0; i < order.Length; i++)
                sb.Append(order[i], priorityArr[i]);

            return sb.Append(otherChars).ToString();
        }

        private string Solution3(string order, string s)
        {
            var n = order.Length;
            var priorityDic = new Dictionary<char, int>();
            for (var i = 0; i < n; i++)
                priorityDic[order[i]] = i;

            var queue = new PriorityQueue<char, int>();
            foreach (var c in s)
                if (priorityDic.ContainsKey(c))
                    queue.Enqueue(c, priorityDic[c]);
                else
                    queue.Enqueue(c, n);

            var sb = new StringBuilder();
            while (queue.Count > 0)
                sb.Append(queue.Dequeue());

            return sb.ToString();
        }
    }
}
