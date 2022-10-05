using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int currentNum = 0;
            int lastNum = int.MinValue;
            int sequenceCounter = 0;
            int maxCounter = 0;
            int sequenceNum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                currentNum = array[i];

                if (currentNum == lastNum)
                {
                    sequenceCounter++;
                }
                else
                {
                    sequenceCounter = 1;
                }

                if (sequenceCounter > maxCounter)
                {
                    maxCounter = sequenceCounter;
                    sequenceNum = currentNum;
                }

                lastNum = currentNum;
            }

            for (int i = 0; i < maxCounter; i++)
            {
                Console.Write($"{sequenceNum} ");
            }
        }
    }
}
