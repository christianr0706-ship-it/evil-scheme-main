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
    }
}
