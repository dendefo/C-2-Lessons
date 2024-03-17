using System.Text.Json;
using System.Text.Json.Serialization;

namespace C_2_Lessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            path = Directory.GetParent(path).Parent.Parent.FullName;
            var text = File.ReadAllText(path + "\\Noldor.json");
            ElfJsonData data = JsonSerializer.Deserialize<ElfJsonData>(text);

            //Moved Data into a JSon, and now i'm reading it from there
            //Divide Data and Logic!

            Console.WriteLine("Family Tree of Noldor. The Visualization is placed is in root-folder/TreeVisualization.png\n\n");


            TreeStructure<Elf> tree = new TreeStructure<Elf>(new Elf(data.root));
            foreach (var i in data.nodes)
            {
                tree.AddNode(x => x.Data.Name == i.parentName, new Elf(i.name));
            }


            Breadth(tree);
            Depth(tree);

            Console.WriteLine("\n\nSorted By name:\n_______________________");
            tree.OrderBy(x => x.Data.Name).ToList().ForEach(x => Console.WriteLine(x.ID + " " + x));

            Console.WriteLine("\n\nSorted By name length:\n_______________________");
            tree.OrderBy(x => x.Data.Name.Length).ThenBy(x => x.Data.Name).ToList().ForEach(x => Console.WriteLine(x.ID + " " + x));
        }
        static void Breadth(TreeStructure<Elf> tree)
        {
            tree.SetIterationMethod(false);
            Console.WriteLine("Iterating through the tree by Breadth:\n__________________________________");
            foreach (var i in tree)
            {
                Console.WriteLine(new string(' ', i.Depth * 2) + i.ID + " " + i);
            }
        }
        static void Depth(TreeStructure<Elf> tree)
        {
            tree.SetIterationMethod(true);
            Console.WriteLine("\nIterating through the tree by Depth:\n__________________________________");
            foreach (var i in tree)
            {
                Console.WriteLine(new string(' ', i.Depth * 2) + i.ID + " " + i);
            }
        }
    }
    class ElfJsonData
    {
        public string root { get; set; }
        public IList<NodeData> nodes { get; set; }
    }
    class NodeData
    {
        public string name { get; set; }
        public string parentName { get; set; }
    }
}