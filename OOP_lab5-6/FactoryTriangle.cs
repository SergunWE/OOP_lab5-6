using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab5_6
{
    class FactoryTriangle
    {
        public static ITriangle CreateObject(int fSide, int sSide, int angle)
        {
			if (angle == 90)
			{
				return new RightTriangle(fSide, sSide);
			}
			if (fSide == sSide)
			{
				if (angle == 60)
				{
					return new EquilateralTriangle(fSide);
				}
				return new IsoscelesTriangle(fSide, angle);
			}
			return new Triangle(fSide, sSide, angle);
		}
    }
}
