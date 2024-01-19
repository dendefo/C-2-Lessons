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
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" (Rolling for Accuracy) ");
            if (HitChance.Roll() > Accuracy*100) { Console.ForegroundColor = color; Console.Write(0); return; }
            Console.ForegroundColor = color;
            base.Attack(unit);
        }
        public RangedUnit(int damage, int hp, float accuracy) : base(new Dice(1, 20, damage), hp)
        {
            Accuracy = accuracy;
            HitChance = new(1, 100, -damage);
        }
    }
}
