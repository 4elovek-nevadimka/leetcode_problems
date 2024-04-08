namespace Solutions.Simulation
{
    internal class Task_1700
    {
        // #Array #Stack #Queue #Simulation

        public void Run()
        {
            Console.WriteLine(CountStudents([1, 1, 0, 0], [0, 1, 0, 1]));
            Console.WriteLine(CountStudents([1, 1, 1, 0, 0, 1], [1, 0, 0, 0, 1, 1]));
        }

        public int CountStudents(int[] students, int[] sandwiches)
        {
            var queue = new Queue<int>(students.Length);
            foreach (var student in students)
                queue.Enqueue(student);
            
            var stack = new Stack<int>(sandwiches.Length);
            foreach (var sandwich in sandwiches.Reverse())
                stack.Push(sandwich);

            while (stack.Count > 0)
            {
                var exitCounter = queue.Count;
                while (exitCounter > 0)
                {
                    if (queue.Peek() == stack.Peek())
                    {
                        queue.Dequeue();
                        stack.Pop();
                        exitCounter = queue.Count;
                    }
                    else
                    {
                        queue.Enqueue(queue.Dequeue());
                        exitCounter--;
                    }
                }
                if (exitCounter == 0) break;
            }

            return queue.Count;
        }
    }
}
