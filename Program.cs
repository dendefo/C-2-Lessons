namespace C_2_Lessons
{
    internal class Program
    {
        const int DECK_SIZE = 40;
        const int DICE_SCALAR = 1;
        const int DICE_BASE = 20;
        const int DICE_MODIFIER = 0;

        static void Main(string[] args)
        {
            Deck<int> deck = new Deck<int>(DECK_SIZE);
            for (int i = 0; i < deck.Size; i++)
            {
                deck.AddCard(i);
            }
            deck.Shuffle();
            IntegerDice dice = new IntegerDice(DICE_SCALAR, DICE_BASE, DICE_MODIFIER);
            RandomFighter(deck, dice);
        }
        static void RandomFighter(Deck<int> deck, Dice<int> dice)
        {
            int DieWins = 0;
            int DeckWins = 0;
            int ties = 0;
            while (deck.TryDraw(out int card))
            {
                int roll = dice.Roll();
                if (roll > card) DieWins++;
                else if (roll == card) ties++;
                else DeckWins++;
            }
            Console.WriteLine($"Dice Wins: {DieWins}\nDeck Wins: {DeckWins}\nTies: {ties}");
        }
    }
}