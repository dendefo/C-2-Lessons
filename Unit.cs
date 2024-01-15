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
        public int IdInStatSystem { get; protected set; }
        public virtual int Damage { get; protected set; }

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
        protected virtual void Defend(Unit unit) => HP -= unit.Damage;
        public enum Races
        {
            Human,
            Dwarf,
            Elf
        }

        protected Unit(int damage, int hp)
        {
            Damage = damage;
            HP = hp;
        }
    }
}
