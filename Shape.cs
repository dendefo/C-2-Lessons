using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    public abstract class Shape
    {
        virtual public float PositionX { get; protected set; }
        virtual public float PositionY { get; protected set; }
        public float Width { get; protected set; }
        public float Height { get; protected set; }

        abstract public float Area();
        abstract public float Perimeter();
        virtual public void Draw()
        {
            Console.WriteLine(this);
        }
        public Shape(float positionX, float positionY, float width, float height)
        {
            if (width < 0 || height < 0) throw new("Width or Height properties of the shape can not be negative");
            PositionX = positionX;
            PositionY = positionY;
            Width = width;
            Height = height;
        }
    }
}
