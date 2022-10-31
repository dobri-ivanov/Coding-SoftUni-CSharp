using System;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        static void Main()
        {
            StringBuilder result = new StringBuilder();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Beast!")
                {
                    break;
                }

                string type = input;
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = String.Empty;
                if (tokens.Length > 2)
                {
                    gender = tokens[2];
                }

                try
                {
                    if (type == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        result.AppendLine(dog.ToString());
                    }
                    else if (type == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        result.AppendLine(cat.ToString());
                    }
                    else if (type == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        result.AppendLine(frog.ToString());
                    }
                    else if (type == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        result.AppendLine(kitten.ToString());
                    }
                    else if (type == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        result.AppendLine(tomcat.ToString());
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                }
                catch (Exception exeption)
                {

                    Console.WriteLine(exeption.Message);
                }
                
            }
            Console.WriteLine(result.ToString().TrimEnd());
        }

    }
}
