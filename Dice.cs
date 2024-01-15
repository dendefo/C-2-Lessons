using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    internal struct Dice
    {
        public uint Scalar { get; private set; } // controls how many die will roll
        public uint BaseDie { get; private set; } // controls the type of die rolled
        public int Modifier { get; private set; } //ontrols an additive value added to the results

        public Dice(uint scalar, uint baseDie, int modifier)
        {
            Scalar = scalar;
            BaseDie = baseDie;
            Modifier = modifier;
        }

        public int Roll()
        {
            int value = 0;
            for (int i = 0; i < Scalar; i++)
            {
                value += Random.Shared.Next(1, (int)BaseDie + 1);
            }

            return value + (int)Modifier;
        }
        public override string ToString()
        {
            return $"{Scalar}d{BaseDie}"+(Modifier>=0?"+":"")+Modifier;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj == null) return false;
            Dice dObj = (Dice)obj;
            return Scalar == dObj.Scalar && BaseDie == dObj.BaseDie && Modifier == dObj.Modifier;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
