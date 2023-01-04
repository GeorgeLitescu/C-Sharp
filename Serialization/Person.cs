using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public string country { get; set; }

        public IList<Person> GetAllPersons()
        {
            return new List<Person>()
            {
                new Person { name = "Mitica", age = 14, country = "Argentina" },
                new Person { name = "Magdalena", age = 98, country = "Israel" },
                new Person { name = "Ionut", age = 24, country = "Romania" }
            };
        }
    }
}