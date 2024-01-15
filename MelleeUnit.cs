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

            if (Random.Shared.NextDouble() < (double)ParryChance) HP -= unit.Damage.Roll() / 2; 
            else base.Defend(unit);
        }
        public MelleeUnit(int damage, int hp,float parryChance) : base(new Dice(1, 20, damage), hp)
        {
            ParryChance = parryChance;
        }
    }
}
