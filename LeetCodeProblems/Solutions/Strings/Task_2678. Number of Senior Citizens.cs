namespace Solutions.Strings
{
    internal class Task_2678
    {
        // #Array #String

        public int CountSeniors(string[] details)
        {
            int count = 0;
            foreach (var item in details)
                if ((char.GetNumericValue(item[11]) * 10 
                    + char.GetNumericValue(item[12])) > 60)
                    count++;

            return count;
        }
    }
}
