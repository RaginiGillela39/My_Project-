// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Collections.Generic;
namespace SelectPerson
{
    class SelectPerson
    {
        public static void Main(string[] args)
        {
            var people = new List<Person>
            {
                new Person { Name = "Alice", PhoneNumbers = new List<string> { "123", "456" } },
                new Person { Name = "Bob", PhoneNumbers = new List<string> { "789" } }
            };

            // Using Select
            var phoneLists = people.Select(p => p.PhoneNumbers); // Returns List<List<string>>
            foreach (var item in phoneLists)
            {
                Console.WriteLine(item);
            }

            // Using SelectMany
            var phoneNumbers = people.SelectMany(p => p.PhoneNumbers); // Returns List<string>
            foreach (var items in phoneLists)
            {
                Console.WriteLine(items);
            }

            var peopleDt = new List<PersonData>
            {
                new PersonData { Id = 1, Name = "Alice" },
                new PersonData { Id = 2, Name = "Bob" },
                new PersonData { Id = 1, Name = "Charlie" }, // Same Id as Alice, different Name
                new PersonData { Id = 3, Name = "Alice" }, // Same Name, different Id
            };

            var employee = new List<PersonData> {
                new PersonData { Id = 2, Name = "Bob" },
                new PersonData { Id = 4, Name = "David" },
                };

            var distinctPeople = peopleDt.Distinct(); // Requires proper equality implementation
            var distinctById = peopleDt.DistinctBy(p => p.Name ); // Filters by Id

            Console.WriteLine("Distinct:");
            foreach (var person in distinctPeople)
                Console.WriteLine($"{person.Id} - {person.Name}");

            Console.WriteLine("\nDistinctBy:");
            foreach (var person in distinctById)
                Console.WriteLine($"{person.Id} - {person.Name}");

            var exceptPeople= peopleDt.Except(employee).ToList();
            Console.WriteLine("Except:");
            foreach (var person in exceptPeople)
                Console.WriteLine($"{person.Id} - {person.Name}");

            var exceptById = peopleDt.ExceptBy(employee.Select(e=>e.Name),p=>p.Name).ToList();
            Console.WriteLine("ExceptBy:");
            foreach (var person in exceptPeople)
                Console.WriteLine($"{person.Id} - {person.Name}");
        }
    }

public class PersonData
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public override bool Equals(object obj) => obj is PersonData p && p.Id == Id;
    public override int GetHashCode() => Id.GetHashCode();
}
public class Person
    {
        public string? Name { get; set; }
        public List<string>? PhoneNumbers { get; set; }
    }

}