namespace ShapeCalculator.Tests
{
	public class CircleTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		[TestCase(0)]
		[TestCase(-512)]
		[TestCase(double.NegativeZero)]
		[TestCase(double.NegativeInfinity)]
		[TestCase(double.PositiveInfinity)]
		public void CreateInvalid(double radius)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => ShapeFactory.CreateCircle(radius));
		}

		[Test]
		[TestCase(0.512)]
		[TestCase(512)]
		[TestCase(double.MaxValue)]
		public void CreateValid(double radius)
		{
			Assert.DoesNotThrow(() => ShapeFactory.CreateCircle(radius));
		}

		[Test]
		[TestCase(512, 512)]
		public void Radius(double radius, double expectedRadius)
		{
			double radiusFromCircle = ShapeFactory.CreateCircle(radius).Radius;

			Assert.AreEqual(radiusFromCircle, expectedRadius);
		}

		[Test]
		[TestCase(512, 823549.66458264273)]
		public void Area(double radius, double expectedArea)
		{
			double area = ShapeFactory.CreateCircle(radius).Area;
			area = Math.Round(area, 3);

			Assert.AreEqual(area, expectedArea);
		}
	}
}