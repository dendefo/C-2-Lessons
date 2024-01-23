using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    /// <summary>
    /// Base Unit class that implements Damage, HP and functions of attack and defence
    /// </summary>
    public abstract class Unit
    {
        public int CarryingCapacity;

        protected IRandomProvider HitChance;
        protected IRandomProvider DefenceRating;

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
        public virtual IRandomProvider Damage { get; protected set; }

        private int _hp;
        public virtual int HP
        {
            get { return _hp; }
            protected set
            {
                var dmg = _hp - value;
                if (value <= 0) { dmg = _hp; _hp = 0; }
                else _hp = value;
                if (dmg >= 0) Console.Write(dmg);
            }
        }
        public bool IsDead => HP == 0;

        public virtual Races Race { get; protected set; }


        public virtual void Attack(Unit unit) => unit.Defend(this);
        protected virtual void Defend(Unit unit)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" (Rolling for damage) ");
            var dmg = unit.Damage.GetRandom();
            Console.ForegroundColor = color;
            HP -= dmg;
        }


        protected Unit(IRandomProvider damage, int hp)
        {
            Damage = damage;
            HP = hp;
            CarryingCapacity = hp;
        }

        public override string ToString()
        {
            //Regex must have comment! It divides a string by Uppercase letter (UpperCase to Upper Case)
            //Took the regex itself from here https://stackoverflow.com/questions/36147162/c-sharp-string-split-separate-string-by-uppercase
            //Also by removing first 12 characters i removed the namespace name from the output.
            //There is a lot of ways for doing it, but this one works just fine
            var list = Regex.Split(base.ToString().Remove(0, 12), @"(?<!^)(?=[A-Z])");
            return list[0] + " " + list[1];
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
