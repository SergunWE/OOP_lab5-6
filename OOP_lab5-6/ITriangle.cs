using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_lab5_6
{
    public abstract class ITriangle
    {
        public abstract double Perimeter(); //периметр
        public abstract double Area(); //площадь
        public abstract double GetSide(int num); //получение стороны
        public abstract int GetAngle(); //получение угла
    }
}
