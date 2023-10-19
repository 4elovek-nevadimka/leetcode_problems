using Solutions;

namespace Tests
{
    internal class Test_0844
    {
        private Task_0844 _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Task_0844();
        }

        [Test]
        public void Test1()
        {
            var s = "ab#c";
            var t = "ad#c";
            var expected = true;

            var result = _solution.BackspaceCompare(s, t);
            Assert.That(result, Is.EqualTo(expected), $"Wrong Answer!");
        }

        [Test]
        public void Test2()
        {
            var s = "ab##";
            var t = "c#d#";
            var expected = true;

            var result = _solution.BackspaceCompare(s, t);
            Assert.That(result, Is.EqualTo(expected), $"Wrong Answer!");
        }

        [Test]
        public void Test3()
        {
            var s = "a#c";
            var t = "b";
            var expected = false;

            var result = _solution.BackspaceCompare(s, t);
            Assert.That(result, Is.EqualTo(expected), $"Wrong Answer!");
        }

        [Test]
        public void Test4()
        {
            var s = "a##c";
            var t = "#a#c";
            var expected = true;

            var result = _solution.BackspaceCompare(s, t);
            Assert.That(result, Is.EqualTo(expected), $"Wrong Answer!");
        }

        [Test]
        public void Test5()
        {
            var s = "y#fo##f";
            var t = "y#f#o##f";
            var expected = true;

            var result = _solution.BackspaceCompare(s, t);
            Assert.That(result, Is.EqualTo(expected), $"Wrong Answer!");
        }
    }
}
