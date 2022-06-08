using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            BigInteger highestSnowballSnow = 0;
            BigInteger highestSnowballTime = 0;
            BigInteger highestSnowballQuality = 0;
            BigInteger highestSnowballValue = 0;


            for (BigInteger i = 0; i < n; i++)
            {
                BigInteger snowballSnow = BigInteger.Parse(Console.ReadLine());
                BigInteger snowballTime = BigInteger.Parse(Console.ReadLine());
                BigInteger snowballQuality = BigInteger.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), (int)snowballQuality);
                if (snowballValue > highestSnowballValue)
                {
                    highestSnowballSnow = snowballSnow;
                    highestSnowballTime = snowballTime;
                    highestSnowballQuality = snowballQuality;
                    highestSnowballValue = snowballValue;
                }
            }

            Console.WriteLine($"{highestSnowballSnow} : {highestSnowballTime} = {highestSnowballValue} ({highestSnowballQuality})");
        }
    }
}
