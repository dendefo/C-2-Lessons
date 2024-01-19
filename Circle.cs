using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    internal class Circle : Shape
    {
        public float Radius { get; private set; }
        public Circle(float positionX, float positionY, float radius) : base(positionX, positionY, radius * 2, radius * 2)
        {
            Radius = radius;
        }

        public override float Area()
        {
            return MathF.PI * MathF.Pow(Radius, 2);
        }

        public override float Perimeter()
        {
            return 2 * MathF.PI * Radius;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is Circle c) return c.Radius == Radius && c.PositionX == PositionX && c.PositionY == PositionY;
            return false;
        }

        /// <summary>
        /// It may look like a diamond, but if you look very closely, you will se that i don't have patience to make it round
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var str = "";
            for (int i = 0; i < Radius; i++)
            {
                var bef = (int)MathF.Round(Radius * 2 - (MathF.Cos(MathF.Asin((Radius - i) / Radius)) * Radius*1.8f));
                var middle = (int)MathF.Round(2 * (MathF.Cos(MathF.Asin((Radius - i) / Radius)) * Radius *1.1f));
                str += new string(' ', bef) + new string('*', (int)MathF.Round((Radius*2)-(bef/2)-middle/2)) + new string(' ', (int)MathF.Round(middle*2f)) + new string('*', (int)MathF.Round((Radius * 2) - (bef / 2) - middle / 2)) + "\n";
            }
            for (int i = (int)Radius; i >= 0; i--)
            {
                var bef = (int)MathF.Round(Radius * 2 - (MathF.Cos(MathF.Asin((Radius - i) / Radius)) * Radius *1.8f));
                var middle = (int)MathF.Round(2 * (MathF.Cos(MathF.Asin((Radius - i) / Radius)) * Radius*1.1f ));
                str += new string(' ', bef) + new string('*', (int)MathF.Round((Radius * 2) - (bef / 2) - middle / 2)) + new string(' ', (int)MathF.Round(middle * 2f)) + new string('*', (int)MathF.Round((Radius * 2) - (bef / 2) - middle / 2)) + "\n";
            }
            return str;
        }
    }
}
