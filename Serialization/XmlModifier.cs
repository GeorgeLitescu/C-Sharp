using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


namespace Serialization
{
    public class XmlModifier
    {
        Person person = new Person();
        IList<Person> persons = new List<Person>();

        String outputPath = Directory.GetCurrentDirectory() + @"\output.xml";
        String inputPath = Directory.GetCurrentDirectory() + @"\input.xml";

        XmlSerializer xs = new XmlSerializer(typeof(List<Person>));

        public void ReadXml()
        {
            using (FileStream stream = File.Open(inputPath, FileMode.Open))
            {
                persons = (List<Person>)xs.Deserialize(stream);
            }
        }

        public void CreateXml()
        {
            using (FileStream stream = File.Create(outputPath))
            {
                xs.Serialize(stream, persons);
            }
        }

        public void AddPerson(Person person)
        {
            persons.Add(person);
        }

        public Person SearchPerson(Person person)
        {
            foreach (Person personFromDB in persons)
            {
                if (person.Equals(personFromDB))
                    return personFromDB;
            }

            return null;
        }

        public Person SearchName(string name)
        {
            foreach (Person person in persons)
                if (person.name == name)
                    return person;

            return null;
        }

        public bool RemovePerson(Person person)
        {
            try
            {
                persons.RemoveAt(persons.IndexOf(SearchPerson(person)));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}