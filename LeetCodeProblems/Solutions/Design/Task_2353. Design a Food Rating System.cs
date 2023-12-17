namespace Solutions.Design
{
    internal class Task_2353
    {
        public void Run()
        {
            FoodRatings foodRatings = new FoodRatings(
                new[] { "kimchi", "miso", "sushi", "moussaka", "ramen", "bulgogi" }, 
                new[] { "korean", "japanese", "japanese", "greek", "japanese", "korean" }, 
                new[] { 9, 12, 8, 15, 14, 7 });

            // return "kimchi"
            // "kimchi" is the highest rated korean food with a rating of 9.
            Console.WriteLine(foodRatings.HighestRated("korean"));

            // return "ramen"
            // "ramen" is the highest rated japanese food with a rating of 14.
            Console.WriteLine(foodRatings.HighestRated("japanese"));

            // "sushi" now has a rating of 16.
            foodRatings.ChangeRating("sushi", 16);

            // return "sushi"
            // "sushi" is the highest rated japanese food with a rating of 16.
            Console.WriteLine(foodRatings.HighestRated("japanese"));

            // "ramen" now has a rating of 16.
            foodRatings.ChangeRating("ramen", 16);

            // return "ramen"
            // Both "sushi" and "ramen" have a rating of 16.
            // However, "ramen" is lexicographically smaller than "sushi".
            Console.WriteLine(foodRatings.HighestRated("japanese"));
        }
    }

    public class FoodRatings
    {

        private readonly Dictionary<string, string> cuisineByFood = new();
        private readonly Dictionary<string, int> ratingByFood = new();
        private readonly Dictionary<string, SortedSet<(string food, int rating)>> foodRating = new();

        public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
        {
            for (int i = 0; i < foods.Length; i++)
            {
                cuisineByFood.Add(foods[i], cuisines[i]);
                ratingByFood.Add(foods[i], ratings[i]);
                if (!foodRating.ContainsKey(cuisines[i]))
                {
                    foodRating.Add(cuisines[i], new SortedSet<(string food, int rating)>(new FoodComparer()));
                }
                foodRating[cuisines[i]].Add(new(foods[i], ratings[i]));
            }
        }

        public void ChangeRating(string food, int newRating)
        {
            var cuisine = cuisineByFood[food];
            foodRating[cuisine].Remove(new(food, ratingByFood[food]));
            ratingByFood[food] = newRating;
            foodRating[cuisine].Add(new(food, newRating));
        }

        public string HighestRated(string cuisine)
        {
            return foodRating[cuisine].First().food;
        }
    }

    public class FoodComparer : IComparer<(string food, int rating)>
    {
        public int Compare((string food, int rating) x, (string food, int rating) y)
        {
            if (x.rating == y.rating)
            {
                return string.CompareOrdinal(x.food, y.food);
            }
            return x.rating > y.rating ? -1 : 1;
        }
    }
}
