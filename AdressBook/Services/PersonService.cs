using AdressBook.Models;

namespace AdressBook.Services;

internal class PersonService
{
    private readonly List<Person> _person = [];

    public void AddPersonToList(Person person)
    {
        if (!(_person.Any(X => X.Contact == person.Contact)))
        {
            _person.Add(person);
            Console.WriteLine("Person added to list");
        }
        else
            Console.WriteLine("E-mail adress already exists");
        
    }
    public Person GetPersonFromList(Person person)
    {
        var input = _person.FirstOrDefault(x => x.Contact == person.Contact);
        return person ??= null!;
    }

    public void DeletePersonFromList(Person person)
    {
        if ((_person.Any(X => X.Contact == person.Contact)))
        {
            _person.Remove(person);
            Console.WriteLine("Person removed from list.");
        }
        else
            Console.WriteLine("E-mail adress was not found.");
    }

    public void ShowAllPersonsFromList()
    {
        foreach (var person in _person)
        {
            Console.WriteLine($"{person.FirstName}{person.LastName}{person.Contact}{person.Adress}");
        }
    }

    public void ShowOnePersonFromList(Person person)
    {
        if ((_person.Any(X => X.Contact == person.Contact)))
        {
            Console.WriteLine(person);
        }

        else
            Console.WriteLine("E-mail adress was not found.");
    }
}

