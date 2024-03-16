using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    public struct Elf
    {
        public string Name { get; private set; }
        public int ID { get; private set; }
        public Elf(string name, int Id)
        {
            Name = name;
            ID = Id;
        }
        public override string ToString()
        {
            return ID + " " + Name;
        }
    }
}
