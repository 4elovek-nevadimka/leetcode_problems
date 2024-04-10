namespace Solutions.Simulation
{
    internal class Task_0950
    {
        // #Array #Queue #Sorting #Simulation

        public void Run()
        {
            var arr = DeckRevealedIncreasing([17, 13, 11, 2, 3, 5, 7]);
            Array.ForEach(arr, Console.Write);
        }

        public int[] DeckRevealedIncreasing(int[] deck)
        {
            Array.Sort(deck);
            var queue = new Queue<int>(deck.Length);
            queue.Enqueue(deck[^1]);
            for (var i = deck.Length - 2; i >= 0; i--)
            {
                var card = queue.Dequeue();
                queue.Enqueue(card);
                queue.Enqueue(deck[i]);
            }

            return [.. queue.Reverse()];
        }
    }
}
