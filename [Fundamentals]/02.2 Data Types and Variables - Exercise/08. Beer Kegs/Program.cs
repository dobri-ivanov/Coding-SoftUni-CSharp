using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string bigggestKeg = string.Empty;
            double biggestVolume = 0;

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;
                if (volume > biggestVolume)
                {
                    biggestVolume = volume;
                    bigggestKeg = model;
                }
            }
            Console.WriteLine(bigggestKeg);
        }
    }
}
