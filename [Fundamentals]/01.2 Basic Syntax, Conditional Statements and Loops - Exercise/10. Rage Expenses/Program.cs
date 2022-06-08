using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int gameLost = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int headset = 0;
            int mouse = 0;
            int keyboard= 0;
            int display = 0;

            int gameLostCounter = 0;
            int headsetCounter = 0;
            int mouseCounter = 0;
            int keyboardCounter = 0;

            for (int i = 1; i <= gameLost; i++)
            {
                gameLostCounter++;
                if (gameLostCounter % 2 == 0)
                {
                    headset++;
                    headsetCounter++;
                }
                if (gameLostCounter % 3 == 0)
                {
                    mouse++;
                    mouseCounter++;
                }
                if (headsetCounter == 1 && mouseCounter == 1)
                {
                    keyboard++;
                    keyboardCounter++;
                    headsetCounter = 0;
                    mouseCounter = 0;
                }
                if (keyboardCounter == 2)
                {
                    display++;
                    keyboardCounter = 0;
                }
                headsetCounter = 0;
                mouseCounter = 0;
            }

            //Calc
            double sumHeadset = headset * headsetPrice;
            double sumMouse = mouse * mousePrice;
            double sumKeyboard = keyboard * keyboardPrice;
            double sumDisplay = display * displayPrice;
            double totalSum = sumHeadset + sumMouse + sumKeyboard + sumDisplay;

            Console.WriteLine($"Rage expenses: {totalSum:f2} lv.");
        }
    }
}
