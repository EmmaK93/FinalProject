using AdressBook.Interfaces;

namespace AdressBook.Models;

internal class Persons : IPersons
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set;} = null!;
    public string StreetName {  get; set; } = null!;
    public string CityName { get; set; } = null!;
    public string Email { get; set; } = null!;

}
