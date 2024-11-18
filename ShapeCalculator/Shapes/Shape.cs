using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeCalculator.Shapes
{
	internal abstract class Shape : IShape
	{
		private double? _area;

		public double Area => _area ??= CalculateArea();

		protected abstract double CalculateArea();
	}
}
