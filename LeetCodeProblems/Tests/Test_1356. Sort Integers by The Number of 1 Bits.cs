using Solutions;

namespace Tests
{
    internal class Test_1356
    {
        private Task_1356 _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Task_1356();
        }

        [Test]
        public void Test1()
        {
            var arr = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            var expected = new[] { 0, 1, 2, 4, 8, 3, 5, 6, 7 };

            var result = _solution.SortByBits(arr);
            Assert.That(result, Is.EqualTo(expected), $"Wrong Answer!");
        }

        [Test]
        public void Test2()
        {
            var arr = new[] { 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 };
            var expected = new[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024 };

            var result = _solution.SortByBits(arr);
            Assert.That(result, Is.EqualTo(expected), $"Wrong Answer!");
        }

        [Test]
        public void Test3()
        {
            var arr = new[] { 7850, 8192, 1878, 2687, 6878, 7410, 763, 365, 9869, 8744, 2741, 4871, 5844, 2715, 3335, 9651, 6677 };
            var expected = new[] { 8192, 8744, 365, 3335, 4871, 6677, 1878, 2715, 2741, 5844, 9869, 763, 7410, 7850, 9651, 2687, 6878 };

            var result = _solution.SortByBits(arr);
            Assert.That(result, Is.EqualTo(expected), $"Wrong Answer!");
        }
    }
}
