using _01._Single_Inheritance;
using System;

namespace Farm
{
    internal class Program
    {
        static void StartUp()
        {
            Dog dog = new Dog();
            dog.Eat();
            dog.Bark();

            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();
        }
    }
}
