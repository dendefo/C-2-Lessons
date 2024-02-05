using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    public class Bag : IRandomProvider
    {
        public int Minimum { get; protected set; }
        public int Maximum { get; protected set; }
        public int Modifier { get; set; }
        private List<int> fromMinToMax;

        public int GetRandom()
        {
            int value = fromMinToMax[Random.Shared.Next(0, fromMinToMax.Count)] + Modifier;
            fromMinToMax.Remove(value - Modifier);
            if (fromMinToMax.Count == 0) Fill();
            Console.Write($" number from {Minimum} to {Maximum}  ");
            return value;
        }
        private void Fill()
        {
            //https://stackoverflow.com/questions/4926362/easier-way-to-populate-a-list-with-integers-in-net
            fromMinToMax = Enumerable.Range(Minimum, Maximum).ToList();
        }
        public Bag(int min, int max, int mod)
        {
            Minimum = min;
            Maximum = max;
            Modifier = mod;
            Fill();
        }
    }
}
