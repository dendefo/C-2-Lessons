using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    public abstract class MelleeUnit : Unit
    {
        protected float ParryChance { get; set; }
        protected override void Defend(Unit unit)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" (Rolling for parrying) ");
            if (DefenceRating.Roll() < ((double)ParryChance) * 100)
            {
                Console.ForegroundColor = color;
                HP -= unit.Damage.Roll() / 2;

            }
            else
            {
                Console.ForegroundColor = color;
                base.Defend(unit);
            }

        }
        public MelleeUnit(int damage, int hp, float parryChance) : base(new Dice(1, 20, damage), hp)
        {
            ParryChance = parryChance;
            DefenceRating = new(1, 100, -HP);
        }
    }
}
