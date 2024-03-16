namespace C_2_Lessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Family Tree of Noldor. The Visualization is placed is in root-folder/TreeVisualization.png\n\n");
            TreeStructure<Elf> tree = new TreeStructure<Elf>(new Elf("Finwe",0));
            TreeNode<Elf> node = tree.Root;
            tree.AddNode(node, new Elf("Feanor",1));
            tree.AddNode(node, new Elf("Fingolfin",2));
            tree.AddNode(node, new Elf("Finarfin",3));
            tree.AddNode(node.Children[0], new Elf("Maedros",4));
            tree.AddNode(node.Children[0], new Elf("Maglor",5));
            tree.AddNode(node.Children[0], new Elf("Celegorm",6));
            tree.AddNode(node.Children[0], new Elf("Carantihir",7));
            tree.AddNode(node.Children[0], new Elf("Curufin",8));
            tree.AddNode(node.Children[0], new Elf("Amrod",9));
            tree.AddNode(node.Children[0], new Elf("Amras",10));
            tree.AddNode(node.Children[1], new Elf("Fingon",11));
            tree.AddNode(node.Children[1], new Elf("Turgon",12));
            tree.AddNode(node.Children[2], new Elf("Finrod",13));
            tree.AddNode(node.Children[2], new Elf("Orodreth",14));
            tree.AddNode(node.Children[2], new Elf("Angrod",15));
            tree.AddNode(node.Children[2], new Elf("Aegnor",16));
            tree.AddNode(node.Children[2], new Elf("Galadriel",17));
            tree.AddNode(node.Children[0].Children[4], new Elf("Celebrimbor",18));
            tree.AddNode(node.Children[1].Children[0], new Elf("Gil Galad",19));
            tree.AddNode(node.Children[1].Children[1], new Elf("Idril",20));
            tree.AddNode(node.Children[2].Children[1], new Elf("Findulas",21));
            tree.AddNode(node.Children[1].Children[1].Children[0], new Elf("Earendil",22));
            tree.AddNode(node.Children[1].Children[1].Children[0].Children[0], new Elf("Elros",23));
            tree.AddNode(node.Children[1].Children[1].Children[0].Children[0], new Elf("Elrond",24));
            Console.WriteLine("Iterating through the tree by Breadth:\n__________________________________");
            foreach (var i in tree)
            {
                Console.WriteLine(i);
            }
            tree.SetIterationMethod(true);

            var enumerator = ((IEnumerable<TreeNode<Elf>>)tree).GetEnumerator();
            Console.WriteLine("\nIterating through the tree by Depth:\n__________________________________");
            while (enumerator.MoveNext())
            {
                Console.Write(new string(' ',((TreeDepthEnumerator<TreeNode<Elf>, Elf>)(enumerator)).DepthLevel*2));
                Console.WriteLine(enumerator.Current);
            }
            Console.WriteLine("\n\nSorted By name:\n_______________________");
            tree.OrderBy(x => x.Data.Name).ToList().ForEach(x =>Console.WriteLine(x));
        }
    }
}