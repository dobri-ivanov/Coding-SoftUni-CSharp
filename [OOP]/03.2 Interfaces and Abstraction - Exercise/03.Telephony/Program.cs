using System;
using System.Net.Http.Headers;

namespace _03.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                string currentPhoneNumber = phoneNumbers[i];

                bool next = false;
                foreach (var symbol in currentPhoneNumber)
                {
                    if (!char.IsDigit(symbol))
                    {
                        next = true;
                        Console.WriteLine("Invalid number!");
                        break;
                    }
                }
                if (next)
                {
                    break;
                }

                if (currentPhoneNumber.Length == 10)
                {
                    ISmartPhone phone = new Smartphone();
                    phone.Call(currentPhoneNumber);
                }
                else if (currentPhoneNumber.Length == 7)
                {
                    IStationaryPhone phone = new StationaryPhone();
                    phone.Call(currentPhoneNumber);
                }
            }

            for (int i = 0; i < urls.Length; i++)
            {
                string currentUrl = urls[i];
                bool next = false;
                foreach (var symbol in currentUrl)
                {
                    if (char.IsDigit(symbol))
                    {
                        next = true;
                        Console.WriteLine("Invalid URL!");
                        break;
                    }
                }

                if (next)
                {
                    break;
                }

                ISmartPhone phone = new Smartphone();
                phone.Browse(currentUrl);
            }
        }
    }
}
