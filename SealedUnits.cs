﻿namespace C_2_Lessons
{
    /// <summary>
    /// Classes are referenced to Hearthstone, cause i have zero imagination
    /// </summary>
    #region Dwarfs
    public sealed class DwarfWarrior : MelleeUnit
    {
        private static readonly int hp = 22;
        private static readonly int damageModifier = 3;
        private static readonly float parry = 0.02f;
        public DwarfWarrior() : base(damageModifier, hp, parry)
        {
            Race = Races.Dwarf;
            IdInStatSystem = 0;
        }
        public override void Attack(Unit unit)
        {
            if (HP < hp / 2) Damage.ChangeModifier((int)(damageModifier * 1.5f)); //RAGE (Shadow legends)
            base.Attack(unit);
        }
    }
    public sealed class DwarfHunter : RangedUnit
    {
        private static readonly int hp = 15;
        private static readonly int damageModifier = 8;
        private static readonly float accuracy = 0.92f;
        public DwarfHunter() : base(damageModifier, hp, accuracy)
        {
            Race = Races.Dwarf;
            IdInStatSystem = 1;
        }
        public override void Attack(Unit unit)
        {
            if (HP < hp / 2) Damage.ChangeModifier(damageModifier / 3 * 2); //Bad Wounds
            base.Attack(unit);
        }
    }
    public sealed class DwarfPaladin : MelleeUnit
    {
        private static readonly int hp = 25;
        private static readonly int damageModifier = 3;
        private static readonly float parry = 0.1f;
        public DwarfPaladin() : base(damageModifier, hp, parry)
        {
            Race = Races.Dwarf;
            IdInStatSystem = 2;
        }
        protected override void Defend(Unit unit)
        {
            int hpBeforeDefence = HP;
            base.Defend(unit);
            if (HP == hpBeforeDefence) Attack(unit); //Ofensive Parrying
        }
    }
    #endregion

    #region Humans
    public sealed class HumanRogue : MelleeUnit
    {
        private static readonly int hp = 10;
        private static readonly int damageModifier = 5;
        private static readonly float parry = 0.2f;
        public HumanRogue() : base(damageModifier, hp, parry)
        {
            Race = Races.Human;
            IdInStatSystem = 3;
        }
        protected override void Defend(Unit unit)
        {
            if (IsDead) return;
            base.Defend(unit);
            Console.Write(" damage, but he threw his last dagger and also dealt ");
            if (IsDead) Attack(unit); //Last stab
        }
    }
    public sealed class HumanWarlock : RangedUnit
    {
        private static readonly int hp = 17;
        private static readonly int damageModifier = 5;
        private static readonly float accuracy = 0.9f;
        public HumanWarlock() : base(damageModifier, hp, accuracy)
        {
            Race = Races.Human;
            IdInStatSystem = 4;
        }

    }
    public sealed class HumanMage : RangedUnit
    {
        private static readonly int hp = 20;
        private static readonly int damageModifier = 4;
        private static readonly float accuracy = 1f;
        public HumanMage() : base(damageModifier, hp, accuracy)
        {
            Race = Races.Human;
            IdInStatSystem = 5;
        }
    }
    #endregion

    #region Elfs
    public sealed class ElfDruid : MelleeUnit
    {
        private static readonly int hp = 25;
        private static readonly int damageModifier = 3;
        private static readonly float parry = 0.1f;
        public ElfDruid() : base(damageModifier, hp, parry)
        {
            Race = Races.Elf;
            IdInStatSystem = 6;
        }
    }
    public sealed class ElfPriest : RangedUnit
    {
        private static readonly int hp = 11;
        private static readonly int damageModifier = 5;
        private static readonly float accuracy = 0.9f;
        public ElfPriest() : base(damageModifier, hp, accuracy)
        {
            Race = Races.Elf;
            IdInStatSystem = 7;
        }
        protected override void Defend(Unit unit)
        {
            base.Defend(unit);
            if (IsDead) return;
            Heal();
        }
        private void Heal() => HP += 2; //Priest must heal
    }
    public sealed class ElfShaman : RangedUnit
    {
        private static readonly int hp = 25;
        private static readonly int damageModifier = 4;
        private static readonly float accuracy = 0.85f;
        public ElfShaman() : base(damageModifier, hp, accuracy)
        {
            Race = Races.Elf;
            IdInStatSystem = 8;
        }
    }
    #endregion
}
