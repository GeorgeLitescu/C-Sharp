using System.Collections.Generic;


namespace Serialization
{
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public string country { get; set; }

        public bool Equals(Person person)
        {
            if (person == null)
                return false;

            if (this.name == person.name &&
                this.age == person.age &&
                this.country == person.country)
                return true;

            return false;
        }
        public Person ChangeData(string name, int age, string country)
        {
            this.name = name;
            this.age = age;
            this.country = country;
            return this;
        }
    }
}