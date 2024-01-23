namespace C_2_Lessons
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Triangle tri = new(5,5,2.587f,5,60);
            Console.WriteLine(tri);
            Square square = new(5, 5, 5);
            Console.WriteLine(square);
            Circle circle = new(5, 5, 5);
            Console.WriteLine(circle);


        }
    }
}