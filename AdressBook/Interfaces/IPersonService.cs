using AdressBook.Models;

namespace AdressBook.Interfaces;

internal interface IPersonService
{
    void AddPersons(Persons person);
    bool RemovePersons();
    void ShowAllPersons();
    void ShowOnePerson();

}
