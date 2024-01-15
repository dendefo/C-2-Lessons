using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    /// <summary>
    /// Base Unit class that implements Damage, HP and functions of attack and defence
    /// </summary>
    public abstract class Unit
    {
        public int CarryingCapacity;

        public Dice HitChance;
        public Dice DefenceRating;

        private Weather _weathereffect;
        public Weather WeatherEffect
        {
            get { return _weathereffect; }
            set
            {
                int before = (int)_weathereffect;
                _weathereffect = value;
                Damage.ChangeModifier(Damage.Modifier + (int)value - before);
            }
        }

        public int IdInStatSystem { get; protected set; }
        public virtual Dice Damage { get; protected set; }

        private int _hp;
        public virtual int HP
        {
            get { return _hp; }
            protected set
            {
                if (value <= 0) _hp = 0;
                else _hp = value;
            }
        }
        public bool IsDead => HP == 0;

        public virtual Races Race { get; protected set; }


        public virtual void Attack(Unit unit) => unit.Defend(this);
        protected virtual void Defend(Unit unit) => HP -= unit.Damage.Roll();
        

        protected Unit(Dice damage, int hp)
        {
            Damage = damage;
            HP = hp;
        }
    }
    public enum Races
    {
        Human,
        Dwarf,
        Elf
    }
    public enum Weather
    {
        Sunny,
        Rain,
        Snow,
        FreezingRain,
        Huricane,
        FireballsFromTheSky
    }
}
