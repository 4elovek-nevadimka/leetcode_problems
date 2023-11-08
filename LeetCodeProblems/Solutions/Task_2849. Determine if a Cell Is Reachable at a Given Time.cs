namespace Solutions
{
    internal class Task_2849
    {
        public bool IsReachableAtTime(int sx, int sy, int fx, int fy, int t)
        {
            if (t == 1 && sx == fx && sy == fy)
                return false;

            var minDistance = Math.Max(Math.Abs(fx - sx), Math.Abs(fy - sy));
            return minDistance <= t;
        }
    }
}
