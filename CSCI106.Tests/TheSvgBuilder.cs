namespace CSCI106.Tests
{
    public class TheSvgBuilder
    {
        [Test]
        public void BuildsSvgsWithTheCorrectSize()
        {
            var svg = SvgBuilder.New((123, 456)).Build();

            Assert.That(svg, Contains.Substring("width=\"123\""));
            Assert.That(svg, Contains.Substring("height=\"456\""));
        }

        [Test]
        public void AddsRectToSvg()
        {
            var svg = SvgBuilder.New((500, 500)).Rect(10, 20, 100, 200).Build();

            Assert.That(svg, Contains.Substring("<rect x=\"10\" y=\"20\" width=\"100\" height=\"200\" />"));
        }

        [TestCase(10, 20, 100, 200, true)]
        [TestCase(0, 0, 1, 1, true)]
        [TestCase(0, 0, 500, 100, false)]
        [TestCase(-1, 10, 10, 10, false)]
        [TestCase(492, 10, 8, 10, true)]
        [TestCase(492, 10, 9, 10, false)]
        [TestCase(10, 492, 100, 8, true)]
        [TestCase(10, 492, 100, 9, false)]
        [TestCase(100, 100, 0, 10, false)]
        [TestCase(100, 100, 499, 1, false)]
        public void Parameters(int x, int y, int width, int height, bool shouldWork)
        {
            bool inBounds = 
            x >= 0 && x <= 500 && y >= 0 && y <= 500 && width > 0 && width < 500 && height > 0 && height < 500
            && x + width <= 500 && y + height <= 500;
        }
    }
}
