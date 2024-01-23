using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    public interface IRandomProvider
    {
        public int Modifier { get; protected set; }
        public int GetRandom();
        void ChangeModifier(int newMod)
        {
            Modifier = newMod;
        }
    }
}
