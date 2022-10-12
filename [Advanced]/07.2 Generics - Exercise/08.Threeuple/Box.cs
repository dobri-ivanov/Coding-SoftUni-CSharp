using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
    public class Box<T1, T2, T3>
    {
        public Box(T1 value1, T2 value2, T3 value3)
        {
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
        }

        public T1 Value1 { get; set; }
        public T2 Value2 { get; set; }
        public T3 Value3 { get; set; }

        public override string ToString()
        {
            return String.Format($"{Value1} -> {Value2} -> {Value3}");
        }
    }
}
