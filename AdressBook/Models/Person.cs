namespace AdressBook.Models;

internal class Person
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public AdressInfo Adress { get; set; } = null!;
    public ContactInfo Contact { get; set; } = null!;


}
