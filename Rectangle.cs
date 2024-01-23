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
        public bool Intersects(Circle circle)
        {
            //First of all check if side of rectangle is overlaying the circle (or circle is inside the rectangle)
            float[][] corns = Corners();
            if (IsPointInside(circle.PositionX - circle.Width, circle.PositionY, corns)) return true;
            else if (IsPointInside(circle.PositionX + circle.Width, circle.PositionY, corns)) return true;
            else if (IsPointInside(circle.PositionX, circle.PositionY + Height, corns)) return true;
            else if (IsPointInside(circle.PositionX, circle.PositionY - Height, corns)) return true;

            //Check if corner of rectangle isn't inside of circle (or laying on it)
            foreach (var c in corns)
            {
                if (MathF.Pow(MathF.Pow(MathF.Abs(circle.PositionX - c[0]), 2) + MathF.Pow(MathF.Abs(circle.PositionY - c[1]), 2), 0.5f) <= circle.Radius) return true;
            }
            return false;
        }

        private bool IsPointInside(float x, float y, float[][] corns)
        {
            return (x <= corns[3][0] && x >= corns[2][0] &&
                y <= corns[3][1] && y >= corns[4][1]);
        }


        public bool Intersects(Rectangle rect)
        {
            var corns = Corners();
            var rectCorns = rect.Corners();
            //First i check if corners of first rectangle are outside of the second one
            foreach (var point in rectCorns)
            {
                if (IsPointInside(point[0], point[1], corns)) return true;
            }
            //And then i check the reverse (there is a situations where they have different size and i need to check it twice)
            foreach(var point in corns)
            {
                if (IsPointInside(point[0], point[1], rectCorns)) return true;
            }

            return false;
        }

        public override void Draw()
        {
            var str = "╔" + new string('═', (int)Width * 2) + "╗\n";
            for (int i = 0; i < Height; i++)
            {
                str += "║" + new string(' ', (int)Width * 2) + "║\n";
            }
            str += "╚" + new string('═', (int)Width * 2) + "╝\n";
            Console.WriteLine(str);
        }

        /// <summary>
        /// So far easiest one
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() +$", Height: {Height}, Width: {Width}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is Rectangle r) return PositionX == r.PositionX && PositionY == r.PositionY && Width == r.Width && Height == r.Height;
            return false;
        }

    }
}
