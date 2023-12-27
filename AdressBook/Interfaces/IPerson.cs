namespace AdressBook.Interfaces;

public interface IPerson
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    int? PhoneNumber { get; set; }
    string? StreetName { get; set; }
    int? PostalCode { get; set; }
    string CityName { get; set; }

}
