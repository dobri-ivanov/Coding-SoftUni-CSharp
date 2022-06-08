using System;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogs = int.Parse(Console.ReadLine());
            double dogsp = dogs * (2.50);
            int others = int.Parse(Console.ReadLine());
            int othersp = others * (4);
            Console.WriteLine(dogsp + othersp + " lv.");


        }
    }
}
