namespace Solutions.Matrix
{
    internal class Task_0661
    {
        // #Array #Matrix

        public void Run()
        {
            var img = new int[][] { 
                new[] { 100, 200, 100 }, 
                new[] { 200, 50, 200 }, 
                new[] { 100, 200, 100 } };
            var filtered = ImageSmoother(img);
            Array.ForEach(filtered, Console.WriteLine);
            
        }

        public int[][] ImageSmoother(int[][] img)
        {
            int n = img.Length, m = img[0].Length;
            // case 1 x 1
            if (n == 1 && m == 1) return img;

            var filtered = new int[n][];
            for (var i = 0; i < n; i++)
            {
                filtered[i] = new int[m];
                for (var j = 0; j < m; j++)
                {
                    int sum = 0, counter = 0;
                    for (var r = i - 1; r < i + 2; r++)
                    {
                        for (var c = j - 1; c < j + 2; c++)
                        {
                            if (r < 0 || r == n || c < 0 || c == m)
                            {
                                continue;
                            }
                            sum += img[r][c];
                            counter++;
                        }
                    }
                    filtered[i][j] = sum / counter;
                }
            }
            return filtered;
        }
    }
}
