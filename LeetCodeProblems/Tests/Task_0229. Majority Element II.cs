using Solutions;

namespace Tests
{
    public class Test_0229
    {
        private Task_0229 _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Task_0229();
        }

        [Test]
        public void Test1()
        {
            var nums = new[] { 3, 2, 3 };
            var expected = new List<int> { 3 };

            var result = _solution.MajorityElement(nums);
            Assert.That(result, Is.EqualTo(expected), $"Wrong Answer!");
        }

        [Test]
        public void Test2()
        {
            var nums = new[] { 1};
            var expected = new List<int> { 1 };

            var result = _solution.MajorityElement(nums);
            Assert.That(result, Is.EqualTo(expected), $"Wrong Answer!");
        }

        [Test]
        public void Test3()
        {
            var nums = new[] { 1, 2 };
            var expected = new List<int> { 1, 2 };

            var result = _solution.MajorityElement(nums);
            Assert.That(result, Is.EqualTo(expected), $"Wrong Answer!");
        }
    }
}