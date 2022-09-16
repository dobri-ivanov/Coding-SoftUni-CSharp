using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfBarrel = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int value = int.Parse(Console.ReadLine());
            int usedBullets = 0;
            int ammunation = sizeOfBarrel;
            Stack<int> bullets = new Stack<int>(bulletsInput);
            Queue<int> locks = new Queue<int>(locksInput);

            while (bullets.Count > 0)
            {
                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }

                int currentBulletValue = bullets.Pop();
                if (currentBulletValue <= locks.Peek())
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                    ammunation--;
                    usedBullets++;

                    if (ammunation == 0 && bullets.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                        for (int i = 0; i < sizeOfBarrel; i++)
                        {
                            if (bullets.Count > 0)
                            {
                                ammunation++;
                            }
                        }
                    }
                    if (locks.Count == 0)
                    {
                        int moneyEarned = value - (usedBullets * priceOfBullet);
                        Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
                        return;
                    }
                    if (bullets.Count == 0)
                    {
                        Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Ping!");
                    ammunation--;
                    usedBullets++;

                    if (bullets.Count == 0)
                    {
                        Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                        return;
                    }

                    if (ammunation == 0)
                    {
                        Console.WriteLine("Reloading!");
                        for (int i = 0; i < sizeOfBarrel; i++)
                        {
                            if (bullets.Count > 0)
                            {
                                ammunation++;
                            }
                        }
                    }
                }
            }
        }
    }
}