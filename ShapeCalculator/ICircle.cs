using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeCalculator
{
	public interface ICircle : IShape
	{
		double Radius { get; }
	}
}
