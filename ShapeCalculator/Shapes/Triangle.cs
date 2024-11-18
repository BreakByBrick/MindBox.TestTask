using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShapeCalculator.Shapes
{
	internal class Triangle : Shape, ITriangle
	{
		private readonly double _a;
		private readonly double _b;
		private readonly double _c;
		private bool? _isRight;

		public Triangle(double a, double b, double c)
		{
			ArgumentOutOfRangeException.ThrowIfNegativeOrZero(a);
			ArgumentOutOfRangeException.ThrowIfEqual(a, double.PositiveInfinity);

			ArgumentOutOfRangeException.ThrowIfNegativeOrZero(b);
			ArgumentOutOfRangeException.ThrowIfEqual(b, double.PositiveInfinity);

			ArgumentOutOfRangeException.ThrowIfNegativeOrZero(c);
			ArgumentOutOfRangeException.ThrowIfEqual(c, double.PositiveInfinity);

			ValidateSideSum(() => a + b <= c, nameof(c), nameof(a), nameof(b));
			ValidateSideSum(() => a + c <= b, nameof(b), nameof(a), nameof(c));
			ValidateSideSum(() => b + c <= a, nameof(a), nameof(b), nameof(c));

			_a = a;
			_b = b;
			_c = c;

			void ValidateSideSum(Func<bool> predicate, string name1, string name2, string name3)
			{
				if( predicate() )
					return;

				throw new ArgumentOutOfRangeException($"Parameter {name1} must be less then sum of parameters {name2} and {name3}");
			}
		}

		public double A => _a;

		public double B => _b;

		public double C => _c;

		public bool IsRight => _isRight ??= CalculateIsRight();

		protected override double CalculateArea()
		{
			var p = ( _a + _b + _c ) / 2;
			var area = Math.Sqrt(p * ( p - _a ) * ( p - _b ) * ( p - _c ));
			return area;
		}
		
		private bool CalculateIsRight()
		{
			var max = Math.Max(Math.Max(_a, _b), _c);
			var min = Math.Min(Math.Min(_a, _b), _c);
			var mid = _a + _b + _c - max - min;
			var isRight = Math.Pow(min, 2) + Math.Pow(mid, 2) == Math.Pow(max, 2);
			return isRight;
		}
	}
}
