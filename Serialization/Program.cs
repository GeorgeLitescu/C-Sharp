using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlCreator creator = new XmlCreator();
            creator.DefaultXml();
            creator.AddPerson("George", 21, "Romania");
            creator.AddPerson("Miguel", 32, "Mexic");
            creator.CreateXml();
        }
    }

    internal class XmlCreator
    {
        Person person = new Person();
        IList<Person> persons = new List<Person>();
        String path = Directory.GetCurrentDirectory() + @"\people.xml";

        public void CreateXml()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Person>));

            using (FileStream stream = File.Create(path))
            {
                xs.Serialize(stream, persons);
            }
        }

        public void AddPerson(string name, int age, string country)
        {
            persons.Add(new Person
            {
                name = name,
                age = age,
                country = country
            });

            //CreateXml();
        }

        public void DefaultXml()
        {
            persons = person.GetAllPersons();

            //CreateXml();
        }

    }
}