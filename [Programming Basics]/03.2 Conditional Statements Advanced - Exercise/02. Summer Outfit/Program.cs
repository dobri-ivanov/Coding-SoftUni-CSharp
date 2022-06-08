using System;

namespace _02._Summer_Outfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string outfit = "";
            string shoes = "";

            if (degrees >= 10 && degrees <= 18)
            {
                if (type == "Morning")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";

                }
                else if (type == "Afternoon" || type == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";

                }
            }
            else if (degrees > 18 && degrees <= 24)
            {
                if (type == "Afternoon")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (type == "Morning" || type == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }

            }
            else if (degrees >= 25)
            {
                if (type == "Morning")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (type == "Afternoon")
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
                else if (type == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
        }
        
    }
}
