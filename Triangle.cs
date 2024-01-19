using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    /// <summary>
    /// Side of the triangle that lies opposite to angle has same letter in name
    /// </summary>
    internal class Triangle : Shape
    {
        public float side_a { get; private set; }
        public float side_b { get; private set; }
        public float side_c { get; private set; }
        public float angleCAB { get; private set; }
        public float angleABC { get; private set; }
        public float angleBCA { get; private set; }
        public Triangle(float positionX, float positionY, float heightFromBAC, float side_a, float angleABC) : base(positionX, positionY, side_a, heightFromBAC)
        {
            //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHHHHHHHHHHHHH
            //Fuck triangles (but i respect them)
            //Fuck trigonometry (respect it as well)

            this.side_a = side_a;
            this.angleABC = angleABC;
            var tanABC = MathF.Tan(angleABC);
            var partOf_a = heightFromBAC / tanABC;
            var anotherPartOf_a = side_a - partOf_a;
            this.angleBCA = MathF.Atan(heightFromBAC / anotherPartOf_a);
            side_b = heightFromBAC / MathF.Sin(angleBCA);
            side_c = heightFromBAC / MathF.Sin(angleABC);
            angleCAB = 180 - angleABC - angleBCA;
            if (angleBCA <= 0 || angleABC <= 0 || angleCAB <= 0) throw new Exception("Something in the data is wrong, angles are negative");
            if (side_a + side_b <= side_c || side_a + side_c <= side_b || side_b + side_c <= side_a) throw new Exception("Something in the data is wrong, this triangle can't exist");


        }

        public override float Area()
        {
            return Height * side_a / 2;
        }

        public override float Perimeter()
        {
            return side_a + side_b + side_c;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is Triangle t) return side_a == t.side_a && side_b == t.side_b && side_c == t.side_c;
            return false;
        }

        /// <summary>
        /// I have no idea how to draw this to the console, wtf
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
