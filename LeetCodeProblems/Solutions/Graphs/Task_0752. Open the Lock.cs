namespace Solutions.Graphs
{
    internal class Task_0752
    {
        // #Array #Hash Table #String #Breadth-First Search

        private HashSet<string> _deadSet;

        private readonly Queue<string> _queue = new();

        private readonly HashSet<string> _visited = [];

        public int OpenLock(string[] deadends, string target)
        {
            _deadSet = new HashSet<string>(deadends);

            _queue.Enqueue("0000");
            _visited.Add("0000");

            var moves = 0;
            while (_queue.Count > 0)
            {
                var size = _queue.Count;
                for (var i = 0; i < size; i++)
                {
                    var current = _queue.Dequeue();
                    if (_deadSet.Contains(current))
                        continue;

                    if (current == target) 
                        return moves;

                    for (var j = 0; j < 4; j++)
                    {
                        var arr = current.ToCharArray();
                        GenerateNext(arr, j, 1);
                        GenerateNext(arr, j, 8);
                    }
                }
                moves++;
            }
            return -1;
        }

        private void GenerateNext(char[] arr, int index, int shift)
        {
            arr[index] = (char)(((arr[index] - '0' + shift) % 10) + '0');
            var next = new string(arr);
            if (!_visited.Contains(next) && !_deadSet.Contains(next))
            {
                _queue.Enqueue(next);
                _visited.Add(next);
            }
        }
    }
}
