using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    public abstract class RangedUnit : Unit
    {
        public virtual float Accuracy { get; protected set; }

        public override void Attack(Unit unit)
        {
            if ((float)Random.Shared.NextDouble() > Accuracy) return;
            base.Attack(unit);
        }
        public RangedUnit(int damage, int hp, float accuracy) : base(damage, hp)
        {
            Accuracy = accuracy;
        }
    }
}
