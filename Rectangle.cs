using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    internal class Rectangle : Shape
    {

        public Rectangle(float positionX, float positionY, float width, float height) : base(positionX, positionY, width, height)
        {
        }

        public override float Area() => Width * Height;

        public override float Perimeter() => Width * 2 + Height * 2;

        public float[][] Corners() => new float[4][]
            {
                new float[2]{PositionX-(Width/2),PositionY-(Height/2) }, new float[2]{PositionX-(Width/2),PositionY+(Height/2)},
                new float[2]{PositionX+(Width/2),PositionY+(Height/2) }, new float[2]{PositionX+(Width/2),PositionY-(Height/2)}
            };
        public bool Intesects(Circle circle)
        {
            //First of all check if side of rectangle is overlaying the circle (or circle is inside the rectangle)
            float[][] corns = Corners();
            if (circle.PositionX - circle.Width <= corns[3][0] && circle.PositionX - circle.Width >= corns[2][0] &&
                circle.PositionY <= corns[3][1] && circle.PositionY >= corns[4][1]) return true;
            else if (circle.PositionX + circle.Width <= corns[3][0] && circle.PositionX + circle.Width >= corns[2][0] &&
                circle.PositionY <= corns[3][1] && circle.PositionY >= corns[4][1]) return true;
            else if (circle.PositionY + circle.Height <= corns[3][1] && circle.PositionY + circle.Height >= corns[4][1] &&
                circle.PositionX <= corns[3][0] && circle.PositionX >= corns[2][0]) return true;
            else if (circle.PositionY - circle.Height <= corns[3][1] && circle.PositionY - circle.Height >= corns[4][1] &&
                circle.PositionX <= corns[3][0] && circle.PositionX >= corns[2][0]) return true;

            //Check if corner of rectangle isn't inside of circle (or laying on it)
            foreach (var c in corns)
            {
                if (MathF.Pow(MathF.Pow(MathF.Abs(circle.PositionX - c[0]), 2) + MathF.Pow(MathF.Abs(circle.PositionY - c[1]), 2), 0.5f) <= circle.Radius) return true;
            }
            return false;
        }

        public override string ToString()
        {
            var str = "╔" + new string('═', (int)Width * 2) + "╗\n";
            for (int i = 0; i < Height; i++)
            {
                str += "║" + new string(' ', (int)Width * 2) + "║\n";
            }
            str += "╚" + new string('═', (int)Width * 2) + "╝\n";
            return str;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is Rectangle r) return PositionX == r.PositionX && PositionY == r.PositionY && Width == r.Width && Height == r.Height;
            return false;
        }

    }
}
