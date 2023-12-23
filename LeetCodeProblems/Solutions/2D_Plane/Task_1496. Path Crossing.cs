namespace Solutions._2D_Plane
{
    internal class Task_1496
    {
        // #2dPlane
        // #Hashtable #String

        public void Run()
        {
            Console.WriteLine(IsPathCrossing("NESWW"));
        }

        public record struct Point(int X, int Y);

        public bool IsPathCrossing(string path)
        {
            var point = new Point(0, 0);
            var points = new HashSet<Point>() { point };

            foreach (var direction in path)
            {
                switch (direction)
                {
                    case 'N':
                        point.Y++;
                        break;
                    case 'S':
                        point.Y--;
                        break;
                    case 'E':
                        point.X++;
                        break;
                    case 'W':
                        point.X--;
                        break;
                }
                if (!points.Add(point))
                    return true;
            }

            return false;
        }
    }
}
