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
    sealed internal class Triangle : Shape
    {
        public float Side_a { get; private set; }
        public float Side_b { get; private set; }
        public float Side_c { get; private set; }
        public float AngleCAB { get; private set; }
        public float AngleABC { get; private set; }
        public float AngleBCA { get; private set; }
        public Triangle(float positionX, float positionY, float heightFromBAC, float side_a, float angleABC) : base(positionX, positionY, side_a, heightFromBAC)
        {
            //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHHHHHHHHHHHHH
            //Fuck triangles (but i respect them)
            //Fuck trigonometry (respect it as well)

            this.Side_a = side_a;
            this.AngleABC = angleABC;
            var tanABC = MathF.Tan(angleABC/180*(float)Math.PI);
            var partOf_a = heightFromBAC / tanABC;
            var anotherPartOf_a = MathF.Abs(side_a - partOf_a);
            this.AngleBCA = MathF.Atan(heightFromBAC / anotherPartOf_a)/(float)Math.PI*180;
            Side_b = heightFromBAC / MathF.Sin(AngleBCA / 180 * (float)Math.PI);
            Side_c = heightFromBAC / MathF.Sin(angleABC / 180 * (float)Math.PI);
            AngleCAB = 180 - angleABC - AngleBCA;
            if (AngleBCA <= 0 || angleABC <= 0 || AngleCAB <= 0) throw new Exception("Something in the data is wrong, angles are negative");
            if (side_a + Side_b <= Side_c || side_a + Side_c <= Side_b || Side_b + Side_c <= side_a) throw new Exception("Something in the data is wrong, this triangle can't exist");

            
            //After some debug i found out that Trygonometric functions in C# are taking angle argument as radians, and not as "angle"
            //Thanks for nothing documentation about it in IDE, C#
        }

        public override float Area()
        {
            return Height * Side_a / 2;
        }

        public override float Perimeter()
        {
            return Side_a + Side_b + Side_c;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is Triangle t) return Side_a == t.Side_a && Side_b == t.Side_b && Side_c == t.Side_c;
            return false;
        }

        /// <summary>
        /// I have no idea how to draw triangle to the console, so take this raw info about triangle:
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"PositionX: {PositionX}, PositionY: {PositionY}\nSides: {Side_a}, {Side_b}, {Side_c}\nAngles: {AngleABC}, {AngleBCA}, {AngleCAB}";
        }

        /// <summary>
        /// Does it meaningful?
        /// For me it was very meaningful
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (int)(AngleABC * AngleABC * AngleBCA * AngleBCA * AngleBCA * PositionX * PositionY*287361); // 287361 is just a magic number
        }
    }
}
