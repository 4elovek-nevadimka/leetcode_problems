namespace Solutions.Simulation
{
    internal class Task_2751
    {
        // #Array #Stack #Sorting #Simulation

        public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
        {
            var n = positions.Length;
            var indices = new int[n];
            
            for (var i = 0; i < n; i++)
                indices[i] = i;

            Array.Sort(indices, (a, b) => positions[a].CompareTo(positions[b]));

            var stack = new Stack<int>();
            foreach (var index in indices)
            {
                if (directions[index] == 'R')
                {
                    stack.Push(index);
                }
                else
                {
                    while (stack.Count > 0 && healths[index] > 0)
                    {
                        var lastIndex = stack.Pop();
                        if (healths[lastIndex] > healths[index])
                        {
                            healths[lastIndex]--;
                            healths[index] = 0;
                            stack.Push(lastIndex);
                        }
                        else if (healths[lastIndex] < healths[index])
                        {
                            healths[lastIndex] = 0;
                            healths[index]--;
                        }
                        else
                        {
                            healths[lastIndex] = 0;
                            healths[index] = 0;
                        }
                    }
                }
            }

            var survivedRobots = new List<int>();
            for (var i = 0; i < n; i++)
                if (healths[i] > 0)
                    survivedRobots.Add(healths[i]);

            return survivedRobots;
        }
    }
}
