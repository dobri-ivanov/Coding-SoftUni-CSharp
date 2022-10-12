using System;
using System.Collections.Generic;
using System.Text;

namespace _06.GenericCountMethodDouble
{
    public class Box<T> where T : IComparable
    {
        public Box()
        {
            this.Items = new List<T>();
        }
        public List<T> Items { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Items)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString().TrimEnd();
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            T temp = Items[firstIndex];
            Items[firstIndex] = Items[secondIndex];
            Items[secondIndex] = temp;
        }

        public int Count(T text)
        {
            int count = 0;
            foreach (var item in Items)
            {
                int n = item.CompareTo(text);
                if (n == 1)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
