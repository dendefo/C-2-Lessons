using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    //Problems?
    sealed internal class Square : Rectangle
    {
        public Square(float positionX, float positionY, float side) : base(positionX, positionY, side, side)
        {
        }
    }
}
