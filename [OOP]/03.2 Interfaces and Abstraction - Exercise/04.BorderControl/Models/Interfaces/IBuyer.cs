using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl.Models.Interfaces
{
    public interface IBuyer
    {
        public string Name { get; set; }
        public int Food { get; set; }
        public int BuyFood();
    }
}
