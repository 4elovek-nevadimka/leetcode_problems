namespace Solutions.Mathematics
{
    internal class Task_1823
    {
        // #Array #Math #Recursion #Queue #Simulation

        public int FindTheWinner(int n, int k)
        {
            return Solution1(n, k);
        }

        private int Solution1(int n, int k)
        {
            var queue = new Queue<int>(n);
            for (var i = 1; i <= n; i++)
                queue.Enqueue(i);

            while (queue.Count > 1)
            {
                for (var i = 0; i < k - 1; i++)
                    queue.Enqueue(queue.Dequeue());

                queue.Dequeue();
            }

            return queue.Dequeue();
        }

        private int Solution2(int n, int k)
        {
            var list = new List<int>(n);
            for (var i = 1; i <= n; i++)
                list.Add(i);

            int index = 0;
            while (list.Count > 1)
            {
                index = (index + k - 1) % list.Count;
                list.RemoveAt(index);
            }

            return list[0];
        }

        private int Solution3(int n, int k)
        {
            int winner = 0;
            for (int i = 2; i <= n; i++)
                winner = (winner + k) % i;

            return winner + 1;
        }
    }
}
