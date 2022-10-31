
namespace PersonSolution
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {
        }
        public override int Age
        {
            get { return base.Age; }
            set { if(value <= 15 && value >= 0) base.Age = value; }
        }
    }
}
