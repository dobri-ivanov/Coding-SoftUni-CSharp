﻿using System;

namespace _03._Numbers_1_to_N_with_Step_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int n = int.Parse(Console.ReadLine());

            //Loop
            for (int i = 1; i <= n; i+= 3)
            {
                Console.WriteLine(i);
            }

        }
    }
}
