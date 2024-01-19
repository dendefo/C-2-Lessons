using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    public abstract class Shape
    {
        private float _positionX;
        virtual public float PositionX { get { return _positionX; } protected set { _positionX = value; } }

        private float _positionY;
        virtual public float PositionY { get { return _positionY; } protected set { _positionY = value; } }

        private float _width;
        public float Width
        {
            get { return _width; }
            protected set { _width = value; }
        }

        private float _height;
        public float Height
        {
            get { return _height; }
            protected set { _height = value; }
        }

        abstract public float Area();
        abstract public float Perimeter();
        virtual public void Draw()
        {
            Console.WriteLine(this);
        }
        public Shape(float positionX, float positionY, float width, float height)
        {
            if (width < 0 || height < 0) throw new("Width or Height properties of the shape can not be negative");
            _positionX = positionX;
            _positionY = positionY;
            _width = width;
            _height = height;
        }
    }
}
