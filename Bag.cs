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
            Console.Write($" number from {Minimum} to {Maximum}  ");
            return value;
        }
        public Bag(int min, int max,int mod)
        {
            Minimum = min; 
            Maximum = max;
            Modifier = mod;
            fromMinToMax = Enumerable.Range(min, max).ToList(); //https://stackoverflow.com/questions/4926362/easier-way-to-populate-a-list-with-integers-in-net
        }
    }
}
