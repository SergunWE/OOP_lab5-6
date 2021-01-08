using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_lab5_6
{
    public class EquilateralTriangle : BaseTriangle
    {
        public override double Perimeter()
        {
            return base.Perimeter();
        }
        public override double Area()
        {
            return _side * _side * Math.Sqrt(3) / 4;
        }
        public override double GetSide(int num)
        {
            switch (num)
            {
                case 1:
                case 2:
                case 3:
                    return _side;
                default:
                    throw new Exception("Неверный номер стороны");
            }
        }
        public override int GetAngle()
        {
            return 60;
        }
        public EquilateralTriangle()
        {
            _side = 0;
        }
        public EquilateralTriangle(int side)
        {
            if (side <= 0)
            {
                throw new Exception("Недопустимая длина стороны");
            }
            _side = side;
        }
        private int _side;
    }
}
