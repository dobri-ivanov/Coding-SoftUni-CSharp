using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            while (nums.Length > 1)
            {
                int[] condesed = new int[nums.Length - 1];
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    condesed[i] = nums[i] + nums[i + 1];
                }
                nums = condesed;
            }
            Console.WriteLine(nums[0]);
        }
    }
}
