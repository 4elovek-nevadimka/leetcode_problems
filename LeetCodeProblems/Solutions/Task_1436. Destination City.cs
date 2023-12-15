namespace Solutions
{
    internal class Task_1436
    {
        // #Hash Table #String
        public string DestCity(IList<IList<string>> paths)
        {
            return Solution2(paths);
        }

        private string Solution1(IList<IList<string>> paths)
        {
            var hash = new HashSet<string>();
            // add "from" cities
            foreach (var path in paths)
            {
                hash.Add(path[0]);
            }
            // check "to" city in list
            foreach (var path in paths)
            {
                if (!hash.Contains(path[1]))
                    return path[1];
            }
            // impossible way
            return string.Empty;
        }

        private string Solution2(IList<IList<string>> paths)
        {
            var destionationCity = paths[0][1];
            var pathIndex = 0;

            while (pathIndex < paths.Count)
            {
                if (destionationCity == paths[pathIndex][0])
                {
                    destionationCity = paths[pathIndex][1];
                    pathIndex = 0;
                }
                else
                {
                    pathIndex++;
                }
            }

            return destionationCity;
        }
    }
}
