using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    public class Elf
    {
        public string Name { get; private set; }
        public Elf(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
