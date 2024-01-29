namespace C_2_Lessons
{
    internal class Program
    {
        public static int[] games = new int[9];
        public static int[] wins = new int[9];
        const float weatherChangeChance = 0.5f;

        static void Main(string[] args)
        {
            BattleBetweenTrainers();
        }

        static void BattleBetweenTrainers()
        {
            Weather weather = new Weather();

            Console.ForegroundColor = ConsoleColor.Black;
            //This is the place to play with some stuff, change races, add units. MAKE THEM FIGHT EACH OTHER
            Trainer inTheRedCorner = new(Races.Elf, 5);
            Trainer inTheBlueCorner = new(Races.Dwarf, 5);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"WELCOME to another day at our kingdom of random!\nToday you will see as Trainer of {inTheRedCorner} " +
                $"race in the red corner with {inTheRedCorner.Units.Count} soldiers and {inTheRedCorner.PokerChips} poker chips.\n" +
                $"He will fight against Trainer of {inTheBlueCorner} " +
                $"race in the blue corner that have {inTheBlueCorner.Units.Count} soldiers adn {inTheBlueCorner.PokerChips} poker chips!\n" +
                $"May the best man/elf/dwarf win!");

            while (!inTheRedCorner.isDead && !inTheBlueCorner.isDead)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                inTheBlueCorner.Attack(inTheRedCorner);

                if (inTheRedCorner.isDead || inTheBlueCorner.isDead) break;

                Console.ForegroundColor = ConsoleColor.Red;
                inTheRedCorner.Attack(inTheBlueCorner);
                if (Random.Shared.NextDouble() < weatherChangeChance)
                {
                    weather++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Weather has changed from {weather - 1} to {weather}");
                    inTheBlueCorner.Units.ForEach(unit => unit.WeatherEffect++);
                    inTheRedCorner.Units.ForEach(unit => unit.WeatherEffect++);
                }

            }
            string WinnerName;
            int takenRes = 0;

            if (inTheRedCorner.isDead && !inTheBlueCorner.isDead)
            {
                WinnerName = "Blue";
                Console.ForegroundColor = ConsoleColor.Blue;
                takenRes = inTheBlueCorner.TakeResources(inTheRedCorner);
            }
            else if (inTheBlueCorner.isDead && !inTheRedCorner.isDead)
            {
                WinnerName = "Red";
                Console.ForegroundColor = ConsoleColor.Red;
                takenRes = inTheRedCorner.TakeResources(inTheBlueCorner);
            }
            else
            {
                //Some crazy edge case just happened when two humans fought each other and in the last battle there were two rogues,
                //they killed each other so nobody won. WHAT ARE THE CHANCES
                Console.WriteLine("Everybody died. Nobody won. What an irony, they fought for nothing in the end. Just endless dark nothing.\n" +
                    "Was it worth it? It is not to us to decide. We are only spectators of this cruel world.");
                return;
            }

            Console.WriteLine($"The Winner is {WinnerName}!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nLet's take the moment and commemorate the heroes that fell in the battle. They have no name, but they had a purpose");
            Console.ForegroundColor = ConsoleColor.Blue;
            inTheBlueCorner.Units.Where(unit => unit.IsDead).ToList().ForEach(unit => Console.WriteLine(unit));
            Console.ForegroundColor = ConsoleColor.Red;
            inTheRedCorner.Units.Where(unit => unit.IsDead).ToList().ForEach(unit => Console.WriteLine(unit));

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"{WinnerName} won {takenRes} PokerChips and now have {(WinnerName == "Blue" ? inTheBlueCorner.PokerChips : inTheRedCorner.PokerChips)} PokerChips. Graz!");
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