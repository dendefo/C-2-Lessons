using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    abstract public class Dice<T> where T : IComparable<T>
    {
        public uint Scalar { get; private set; } // controls how many die will roll
        public uint BaseDie { get; private set; } // controls the type of die rolled
        public T Modifier { get; private set; } //ontrols an additive value added to the results

        public Dice(uint scalar, uint baseDie, T modifier)
        {
            Scalar = scalar;
            BaseDie = baseDie;
            Modifier = modifier;
        }
        public void ChangeModifier(T modifier)
        {
            Modifier = modifier;
        }

        abstract public T Roll();

    }
    public class IntegerDice : Dice<int>
    {
        public IntegerDice(uint scalar, uint baseDie, int modifier) : base(scalar, baseDie, modifier) { }

        public override int Roll()
        {
            int value = 0;
            for (int i = 0; i < Scalar; i++)
            {
                value += new Random().Next(1, (int)BaseDie + 1);
            }
            return value + Modifier;
        }
        public override string ToString()
        {
            return $"{Scalar}d{BaseDie}" + (Modifier >= 0 ? "+" : "") + Modifier;
        }
    }
}
