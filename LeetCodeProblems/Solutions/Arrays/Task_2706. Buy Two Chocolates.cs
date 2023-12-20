namespace Solutions.Arrays
{
    internal class Task_2706
    {
        // #Array #Sorting
        
        public int BuyChoco(int[] prices, int money)
        {
            return Solution2(prices, money);
        }

        private int Solution1(int[] prices, int money)
        {
            Array.Sort(prices);
            var leftover = money - prices[0] - prices[1];
            return leftover < 0 ? money : leftover;
        }

        private int Solution2(int[] prices, int money)
        {
            int priceOne = 101, priceTwo = 101;
            foreach (var price in prices)
            {
                if (price < priceOne)
                {
                    priceTwo = priceOne; priceOne = price;
                }
                else if (price < priceTwo)
                {
                    priceTwo = price;
                }
            }

            var leftover = money - priceOne - priceTwo;
            return leftover < 0 ? money : leftover;
        }
    }
}
