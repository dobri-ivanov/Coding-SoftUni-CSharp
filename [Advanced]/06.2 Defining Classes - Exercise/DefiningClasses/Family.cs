using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
		private List<Person> people;

	    public List<Person> People
		{
			get { return people; }
			set { people = value; }
		}
		public void AddMember(Person person)
		{
			People.Add(person);
		}
		public Person GetOldestMember()
		{
			int oldestPersonAge = int.MinValue;
			string oldestPersonName = string.Empty;
			foreach (var person in people)
			{
				if (person.Age > oldestPersonAge)
				{
					oldestPersonAge = person.Age;
					oldestPersonName = person.Name;
				}
			}
			Person newPerson = new Person(oldestPersonName, oldestPersonAge);
			return newPerson;
		}
		public Family()
		{
			this.People = new List<Person>();
		}

	}
}
