namespace C_2_Lessons
{
    internal class Program
    {
        public static int[] games = new int[9];
        public static int[] wins = new int[9];

        static void Main(string[] args)
        {
            BattleBetweenTrainers();
        }

        static void BattleBetweenTrainers()
        {
            Weather weather = new Weather();
            float weatherChangeChance = 0.3f;
            Trainer inTheRedCorner = new(Races.Human, 5);
            Trainer inTheBlueCorner = new(Races.Dwarf, 5);
            while (!inTheRedCorner.isDead && !inTheBlueCorner.isDead)
            {
                inTheBlueCorner.Attack(inTheRedCorner);
                if (inTheRedCorner.isDead) break;
                inTheRedCorner.Attack(inTheBlueCorner);
                if (Random.Shared.NextDouble()<weatherChangeChance)
                {
                    weather++;
                    inTheBlueCorner.Units.ForEach(unit => unit.WeatherEffect++);
                    inTheRedCorner.Units.ForEach(unit=> unit.WeatherEffect++);
                }
            }
            if (inTheRedCorner.isDead) Console.WriteLine("The Winner is Blue!");
            else Console.WriteLine("The Winner is Red!");

        }
        /// <summary>
        /// A little battle simulation of units fighting each other in random pairs. Shows which class is in meta rn.
        /// </summary>
        /// <param name="args"></param>
        static void SimulateOld()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Unit FirstUnit = null;
                Unit SecondUnit = null;
                switch ((int)(Random.Shared.NextDouble() * 9))
                {
                    case 0: FirstUnit = new DwarfHunter(); break;
                    case 1: FirstUnit = new DwarfPaladin(); break;
                    case 2: FirstUnit = new DwarfWarrior(); break;
                    case 3: FirstUnit = new HumanMage(); break;
                    case 4: FirstUnit = new HumanRogue(); break;
                    case 5: FirstUnit = new HumanWarlock(); break;
                    case 6: FirstUnit = new ElfDruid(); break;
                    case 7: FirstUnit = new ElfPriest(); break;
                    case 8:
                    default: FirstUnit = new ElfShaman(); break;
                }
                switch ((int)(Random.Shared.NextDouble() * 9))
                {
                    case 0: SecondUnit = new DwarfHunter(); break;
                    case 1: SecondUnit = new DwarfPaladin(); break;
                    case 2: SecondUnit = new DwarfWarrior(); break;
                    case 3: SecondUnit = new HumanMage(); break;
                    case 4: SecondUnit = new HumanRogue(); break;
                    case 5: SecondUnit = new HumanWarlock(); break;
                    case 6: SecondUnit = new ElfDruid(); break;
                    case 7: SecondUnit = new ElfPriest(); break;
                    case 8:
                    default: SecondUnit = new ElfShaman(); break;
                }
                while (!FirstUnit.IsDead && !SecondUnit.IsDead)
                {
                    FirstUnit.Attack(SecondUnit);
                    SecondUnit.Attack(FirstUnit);
                }
                games[FirstUnit.IdInStatSystem] += 1;
                games[SecondUnit.IdInStatSystem] += 1;
                if (FirstUnit.IsDead) wins[SecondUnit.IdInStatSystem] += 1;
                if (SecondUnit.IsDead) wins[FirstUnit.IdInStatSystem] += 1;
            }
            for (int i = 0; i < 9; i++)
            {
                switch (i)
                {
                    case 0: Console.Write("Warrior - "); break;
                    case 1: Console.Write("Hunter  - "); break;
                    case 2: Console.Write("Paladin - "); break;
                    case 3: Console.Write("Rogue   - "); break;
                    case 4: Console.Write("Warlock - "); break;
                    case 5: Console.Write("Mage    - "); break;
                    case 6: Console.Write("Druid   - "); break;
                    case 7: Console.Write("Priest  - "); break;
                    case 8: Console.Write("Shaman  - "); break;

                }
                Console.WriteLine($"Percentage: " + (wins[i] / (float)games[i]) * 100);
            }
        }
    }
}