namespace Solutions.Mathematics
{
    internal class Task_1823
    {
        // #Array #Math #Recursion #Queue #Simulation

        public int FindTheWinner(int n, int k)
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
    }
}
