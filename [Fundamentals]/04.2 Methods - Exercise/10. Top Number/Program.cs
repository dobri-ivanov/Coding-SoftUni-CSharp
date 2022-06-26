using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsTopNumber(int num)
        {
            int sum = 0;
            bool holdsOddDigit = false;
            bool isDivisibleBy8 = false;
            string number = num.ToString();

            for (int i = 0; i < number.Length; i++)
            {
                if (int.Parse(number[i].ToString()) % 2 == 1)
                {
                    holdsOddDigit = true;
                }
                sum += int.Parse(number[i].ToString());
            }
            if (sum % 8 == 0)
            {
                isDivisibleBy8 = true;
            }
            if (isDivisibleBy8 && holdsOddDigit)
            {
                return true;
            }
            return false;
        }
    }
}
