using System;


namespace Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlModifier _xmlModifier = new XmlModifier();
            XmlCommands _xmlCommands = new XmlCommands();

            _xmlModifier.ReadXml();

            //_xmlModifier.AddItem(new Person { name = "George", age = 21, country = "Romania" });
            _xmlCommands.AddItem<Person>(_xmlModifier.persons,
                new Person { name = "George", age = 21, country = "Romania" });

            //_xmlModifier.AddItem(new Person { name = "Miguel", age = 32, country = "Mexic" });
            _xmlCommands.AddItem<Person>(_xmlModifier.persons,
                new Person { name = "Miguel", age = 32, country = "Mexic" });

            /*  if (_xmlModifier.SearchPerson(new Person { name = "Magdalena", age = 98, country = "Israel" }) != null)
             *      Console.WriteLine("It exists");
             *  else Console.WriteLine("No entry");
             */

            if (_xmlCommands.SearchItem(_xmlModifier.persons,
                    new Person { name = "Magdalena", age = 98, country = "Israel" }) != null)
                Console.WriteLine("It exists");
            else Console.WriteLine("No entry");


            //_xmlModifier.SearchName("Viorel").ChangeData("Boris", 34, "Germany");

            _xmlCommands.SearchItem<Person>(_xmlModifier.persons, new Person{name = "Viorel", age = 18, country = "Moldova"})
                .ChangeData("Boris", 34, "Germany");

            //_xmlModifier.RemovePerson(_xmlModifier.SearchName("Magdalena"));

            _xmlCommands.RemoveItem<Person>(_xmlModifier.persons, _xmlCommands.SearchItem<Person>(_xmlModifier.persons,
                new Person { name = "Magdalena", age = 98, country = "Israel" }));
           
            _xmlModifier.CreateXml();
        }
    }
}