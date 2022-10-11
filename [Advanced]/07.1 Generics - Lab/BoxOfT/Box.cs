using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public List<T> Elements { get; set; }
        public int Count { get { return this.Elements.Count; } }

        public Box()
        {
            this.Elements = new List<T>();
        }

        public void Add(T element)
        {
            this.Elements.Insert(0 , element);
        }
        public T Remove()
        {
            T element = this.Elements[0];
            this.Elements.RemoveAt(0);
            return element;
        }

    }
}
