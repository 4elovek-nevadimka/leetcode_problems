namespace Solutions.Arrays
{
    internal class Task_0846
    {
        // #Array #Hash Table #Greedy #Sorting

        public void Run()
        {
            Console.WriteLine(IsNStraightHand([1, 2, 3, 6, 2, 3, 4, 7, 8], 3));
        }

        public bool IsNStraightHand(int[] hand, int groupSize)
        {
            if (hand.Length % groupSize != 0)
                return false;

            Array.Sort(hand);
            var primary = new Stack<int>();

            foreach (var card in hand)
                primary.Push(card);

            var slave = new Stack<int>();
            while (primary.Count > 0)
            {
                var groupCounter = 1;
                var previous = primary.Pop();
                while (groupCounter < groupSize)
                {
                    try
                    {
                        var current = primary.Pop();
                        if (previous == current)
                        {
                            // skip
                            slave.Push(current);
                        }
                        else if (previous - current == 1)
                        {
                            // nice
                            groupCounter++;
                            previous = current;
                        }
                        else
                        {
                            // break
                            return false;
                        }
                    }
                    catch (InvalidOperationException ioe)
                    {
                        // empty stack
                        return false;
                    }
                }
                while (slave.Count > 0)
                    primary.Push(slave.Pop());

            }

            return true;
        }
    }
}
