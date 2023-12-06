namespace Solutions
{
    internal class Task_1716
    {
        public void Run()
        {
            Console.WriteLine(TotalMoney(20));
        }

        public int TotalMoney(int n)
        {
            if (n <= 7)
            {
                return n * (n + 1) / 2;
            }
            var currentWeek = 7 * (7 + 1) / 2;
            var totalMoney = currentWeek;
            var fulllWeeks = n / 7;
            for (var i = 1; i < fulllWeeks; i++)
            {
                currentWeek += 7;
                totalMoney += currentWeek;
            }

            var reminderOfWeek = n % 7;
            if (reminderOfWeek > 0)
            {
                var currentReminder = 1 + fulllWeeks;
                totalMoney += currentReminder;
                for (var i = 1; i < reminderOfWeek; i++)
                {
                    totalMoney += ++currentReminder;
                }
            }

            return totalMoney;
        }
    }
}
