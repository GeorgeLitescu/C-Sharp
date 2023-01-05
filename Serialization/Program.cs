using System;


namespace Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlModifier modifier = new XmlModifier();
            modifier.ReadXml();
            modifier.AddPerson(new Person { name = "George", age = 21, country = "Romania" });
            modifier.AddPerson(new Person { name = "Miguel", age = 32, country = "Mexic" });

            if(modifier.SearchPerson(new Person { name = "Magdalena", age = 98, country = "Israel" }) != null)
                Console.WriteLine("It exists");
            else Console.WriteLine("No entry");

            Console.WriteLine("{0} are {1} ani si este din {2}",
                modifier.SearchName("George").name,
                modifier.SearchName("George").age,
                modifier.SearchName("George").country);

            modifier.SearchName("Viorel").ChangeData("Boris", 34, "Germany");

            modifier.RemovePerson(modifier.SearchName("Magdalena"));

            modifier.CreateXml();
        }
    }

    
}