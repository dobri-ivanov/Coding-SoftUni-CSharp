using System;

namespace _08.Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tokens1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = tokens1[0] + " " + tokens1[1];
            string adress = tokens1[2];
            string town = tokens1[3];
            Box<string, string, string> box1 = new Box<string, string, string>(fullName, adress, town);

            string[] tokens2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = tokens2[0];
            int littres = int.Parse(tokens2[1]);
            string state = tokens2[2];
            bool isDrunk = false;
            if (state == "drunk")
            {
                isDrunk = true;
            }
            Box<string, int, bool> box2 = new Box<string, int, bool>(name, littres, isDrunk);

            string[] tokens3 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string secondName = tokens3[0];
            double accBalance = double.Parse(tokens3[1]);
            string bankName = tokens3[2];
            Box<string, double, string> box3 = new Box<string, double, string>(secondName, accBalance, bankName);

            Console.WriteLine(box1);
            Console.WriteLine(box2);
            Console.WriteLine(box3);
        }
    }
}
