using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());

            int countCarsPassed = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{countCarsPassed} total cars passed the crossroads.");
                    break;
                }

                if (input != "green")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    int duration = greenLightDuration;
                    int seconds = freeWindowSeconds;
                    while (duration > 0)
                    {
                        if (queue.Count > 0)
                        {
                            string car = queue.Dequeue();
                            int timeForCar = car.Length;
                            if (duration >= timeForCar)
                            {
                                duration -= timeForCar;
                                countCarsPassed++;
                            }
                            else
                            {
                                if (timeForCar - duration <= seconds)
                                {
                                    duration -= timeForCar;
                                    countCarsPassed++;
                                }
                                else
                                {
                                    int symbol = duration + seconds;
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{car} was hit at {car[symbol]}.");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            duration = 0;
                        }
                    }
                }
            }
        }
    }
}