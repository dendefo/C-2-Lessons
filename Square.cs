using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    //Problems?
    //From the point of functionality there is no problems in this type of inheritance
    //But from the side of logic, there is no need in this class, cause basyclly, i'm just creating a rectangle with equal sides.
    //Like, really, this code just do nothing.
    sealed internal class Square : Rectangle
    {
        public Square(float positionX, float positionY, float side) : base(positionX, positionY, side, side)
        {
        }
        public override string ToString()
        {
            return $"PositionX: {PositionX}, PositionY: {PositionY}, Side: {Height}";
        }
    }
}
