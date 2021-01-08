using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_lab5_6
{
    public abstract class BaseTriangle : ITriangle
    {
        public override double Perimeter()
        {
            return GetSide(1) + GetSide(2) + GetSide(3);
        }
        public override double Area()
        {
            return GetSide(1) * GetSide(2) * Math.Sin(Math.PI * GetAngle() / 180);
        }
        public override int GetAngle()
        {
            return GetAngle();
        }
        public override double GetSide(int num)
        {
            return GetSide(num);
        }
    }
}
