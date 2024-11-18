using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShapeCalculator.Shapes;

namespace ShapeCalculator
{
	public static class ShapeFactory
	{
		public static ICircle CreateCircle(double radius) => new Circle(radius);
		public static ITriangle CreateTriangle(double a, double b, double c) => new Triangle(a, b, c);
	}
}
