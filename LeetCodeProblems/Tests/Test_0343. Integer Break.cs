using Solutions;

namespace Tests
{
    public class Test_0343
    {
        private Task_0343 _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Task_0343();
        }

        [Test]
        public void Test1()
        {
            var n = 1;
            var expected = 1;

            var result = _solution.IntegerBreak(n);
            Assert.That(result, Is.EqualTo(expected), $"Wrong Answer!");
        }

        [Test]
        public void Test2()
        {
            var n = 10;
            var expected = 36;

            var result = _solution.IntegerBreak(n);
            Assert.That(result, Is.EqualTo(expected), $"Wrong Answer!");
        }

        [Test]
        public void Test3()
        {
            var n = 20;
            var expected = 1458;

            var result = _solution.IntegerBreak(n);
            Assert.That(result, Is.EqualTo(expected), $"Wrong Answer!");
        }
    }
}
