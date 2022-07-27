using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            while (true)
            {

                string[] input = Console.ReadLine().Split(" ");
                if (input[0] == "end")
                {
                    break;
                }
                Box box = new Box(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));
                boxes.Add(box);
            }
            List<Box> orderedBoxes = boxes.OrderByDescending(box => box.PriceOfBox).ToList();
            PrintAllBoxes(orderedBoxes);
        }

        static void PrintAllBoxes(List<Box> boxes)
        {
            foreach (var box in boxes)
            {
                Console.WriteLine(box.serialNumber);
                Console.WriteLine($"-- {box.item.name} - ${box.item.price:f2}: {box.quantity}");
                Console.WriteLine($"-- ${box.PriceOfBox:f2}");
            }
        }
    }
    class Item
    {
        public string name { get; set; }
        public decimal price { get; set; }

        public Item(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }
    }

    class Box
    {
        public string serialNumber { get; set; }
        public Item item { get; set; }
        public int quantity { get; set; }
        public decimal PriceOfBox
        {
            get
            {
                return this.item.price * this.quantity;
            }
        }
        public Box(string serNum, string name, int quantity, decimal price)
        {
            this.serialNumber = serNum;
            this.item = new Item(name, price);
            this.quantity = quantity;
            this.item.price = price;
        }
    }

}
