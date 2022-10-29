using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string> 
    {
        public string RandomString()
        {
            Random r = new Random();
            int index = r.Next(0, Count);
            this.RemoveAt(index);
            return this[index];
        }
    }
}
