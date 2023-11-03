namespace Solutions
{
    internal class Task_1441
    {
        public IList<string> BuildArray(int[] target, int n) {
            var targetCounter = 0;
            var intStreamValue = 1;
            var operations = new List<string>();
            while (intStreamValue != target[^1])
            {
                operations.Add("Push");
                if (target[targetCounter] != intStreamValue)
                {
                    operations.Add("Pop");
                }
                else
                {
                    targetCounter++;
                }
                intStreamValue++;
            }
            operations.Add("Push");
            return operations;
        }
    }
}
