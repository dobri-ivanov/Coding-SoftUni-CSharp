using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    public class Box<T1, T2>
    {
        public Box(T1 f1, T2 f2)
        {
            firstObject = f1;
            secondObject = f2;
        }
        public T1 firstObject { get; set; }
        public T2 secondObject { get; set; }

        public override string ToString()
        {
            return String.Format($"{firstObject} -> {secondObject}");
        }
    }
}
