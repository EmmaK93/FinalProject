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

    public void PersonInfo (string firstName, string lastName, string email, int? phoneNumber, string? streetName, int? postalCode, string cityName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
        this.StreetName = streetName;
        this.PostalCode = postalCode;
        this.CityName = cityName;

    }

}
