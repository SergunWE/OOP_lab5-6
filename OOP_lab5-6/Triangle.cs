using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_lab5_6
{
    public class Triangle : BaseTriangle
    {
        public override double Perimeter()
        {
            return base.Perimeter();
        }
        public override int GetAngle()
        {
            return _angle;
        }
        public override double GetSide(int num)
        {
            switch (num)
            {
                case 1:
                    return _fSide;
                case 2:
                    return _sSide;
                case 3:
                    return Math.Sqrt(_fSide * _fSide + _sSide * _sSide - 2 * _fSide * _sSide * Math.Cos(Math.PI * _angle / 180));
                default:
                    throw new Exception("Неверный номер стороны");
            }
        }
       public Triangle()
        {
            _fSide = 0;
            _sSide = 0;
            _angle = 0;
        }
        public Triangle(int fSide, int sSide, int angle)
            {
            if (fSide <= 0 || sSide <= 0)
            {
                throw new Exception("Недопустимая длина стороны");
            }
            if (angle <= 0 || angle >= 180)
            {
                throw new Exception("Недопустимый угол");
            }
            _fSide = fSide;
            _sSide = sSide;
            _angle = angle;
        }

        private int _fSide; //первая сторона
        private int _sSide; //вторая сторона
        private int _angle; //угол
    }
}
