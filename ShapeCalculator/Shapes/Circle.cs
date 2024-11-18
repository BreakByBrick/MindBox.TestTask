using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeCalculator.Shapes
{
	internal class Circle : Shape, ICircle
	{
		private readonly double _radius;

		public Circle(double radius)
		{
			ArgumentOutOfRangeException.ThrowIfNegativeOrZero(radius);
			ArgumentOutOfRangeException.ThrowIfEqual(radius, double.PositiveInfinity);

			_radius = radius;
		}

		public double Radius => _radius;

		protected override double CalculateArea()
		{
			var area = Math.PI * Math.Pow(_radius, 2); ;
			return area;
		}
	}
}
