using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    /// <summary>
    /// This is Actor/Player
    /// </summary>
    internal class Trainer
    {
        private Races race;
        private List<Unit> _units;

        public List<Unit> Units
        {
            get { return _units; }
            set { _units = value; }
        }
        public int PokerChips { get; private set; } //Yes, Poker Chips is my resources 

        public bool isDead => Units.All(unit => unit.IsDead);
        //Random unit of this trainer attacks random unit from enemy
        public void Attack(Trainer enemy)
        {
            var AliveUnits = Units.Where(unit => !unit.IsDead).ToList();
            var EnemyAliveUnits = enemy.Units.Where(unit => !unit.IsDead).ToList();
            var Attacker = AliveUnits[Random.Shared.Next(0, AliveUnits.Count - 1)];
            var Defender = EnemyAliveUnits[Random.Shared.Next(0, EnemyAliveUnits.Count - 1)];

            Console.Write($"{Attacker} attacked {Defender} and dealt him ");
            Attacker.Attack(Defender);
            Console.WriteLine(" damage");

            if (Defender.IsDead && !Attacker.IsDead) Console.WriteLine($"{Attacker} have killed the {Defender}");
            else if (Defender.IsDead && Attacker.IsDead) Console.WriteLine($"{Attacker} and {Defender} both died. " +
                $"Nobody will remember their heroic act, and in couple years their names will be gone from people's memory. " +
                $"They never knew why they fight and they'll never know");
            else if (Attacker.IsDead) Console.WriteLine($"Somehow {Attacker} just died, while attacking, good job {Defender}");
        }
        public Trainer(Races race, int amountOfUnits)
        {
            Units = new();
            this.race = race;
            PokerChips = new Dice(20, 5, 0).Roll();
            for (int i = 0; i < amountOfUnits; i++)
            {
                Units.Add(race switch
                {
                    Races.Human =>
                    Random.Shared.Next(0, 3) switch
                    {
                        0 => new HumanMage(),
                        1 => new HumanRogue(),
                        2 => new HumanWarlock(),
                    },

                    Races.Dwarf =>
                    Random.Shared.Next(0, 3) switch
                    {
                        0 => new DwarfHunter(),
                        1 => new DwarfPaladin(),
                        2 => new DwarfWarrior(),
                    },

                    Races.Elf =>
                    Random.Shared.Next(0, 3) switch
                    {
                        0 => new ElfDruid(),
                        1 => new ElfPriest(),
                        2 => new ElfShaman(),
                    }
                });
            }

        }


        public override string ToString()
        {
            return race.ToString();
        }

        public int TakeResources(Trainer trainer)
        {
            int res = 0;
            Units.Where(unit => !unit.IsDead).ToList().ForEach(unit => res += unit.CarryingCapacity);
            int stolen = Math.Min(res, trainer.PokerChips);
            trainer.PokerChips -= stolen;
            PokerChips += stolen;
            return stolen;
        }
    }
}
