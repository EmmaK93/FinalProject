using AdressBook.Models;

namespace AdressBook.Interfaces;

internal class IPerson : Person
{
    public Person Person { get; set; } = null!;
}
