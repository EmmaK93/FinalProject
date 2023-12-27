using AdressBook.Models;
using AdressBook.Models.Responses;

namespace AdressBook.Interfaces;

public interface IPersonService
{
    IServiceResult AddPersonToList(Person person);
    IServiceResult DeletePersonFromList(Person person, string email);
    IServiceResult ShowAllPersonsFromList();
    IServiceResult ShowOnePersonFromList(string email);
}