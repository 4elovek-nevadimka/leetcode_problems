namespace Solutions
{
    public class Task_1503
    {
        public int GetLastMoment(int n, int[] left, int[] right)
        {
            int maxLeft = 0;
            // Find the maximum distance of ants moving to the left
            foreach (int position in left)
            {
                maxLeft = Math.Max(maxLeft, position);
            }

            int maxRight = 0;
            // Find the maximum distance of ants moving to the right
            foreach (int position in right)
            {
                maxRight = Math.Max(maxRight, n - position);
            }

            // Return the maximum time it takes for all ants to fall off the plank
            return Math.Max(left.Max(), right.Max());
        }

        private int AltSolution1(int n, int[] left, int[] right)
        {
            var maxLeft = left.Length == 0 ? 0 : left.Max();
            var minRight = right.Length == 0 ? n : right.Min();

            return Math.Max(maxLeft, n - minRight);
        }

        private int AltSolution2(int n, int[] left, int[] right)
        {
            var maxLeft = left.Length == 0 ? 0 : GetMax(left);
            var minRight = right.Length == 0 ? n : GetMin(right);

            return Math.Max(maxLeft, n - minRight);
        }

        private int GetMax(int[] arr)
        {
            var maxElement = arr[0];
            for (var index = 1; index < arr.Length; index++)
            {
                if (arr[index] > maxElement)
                    maxElement = arr[index];
            }
            return maxElement;
        }

        private int GetMin(int[] arr)
        {
            var minElement = arr[0];
            for (var index = 1; index < arr.Length; index++)
            {
                if (arr[index] < minElement)
                    minElement = arr[index];
            }
            return minElement;
        }

    }
}