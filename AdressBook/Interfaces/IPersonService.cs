using AdressBook.Models;
using AdressBook.Models.Responses;

namespace AdressBook.Interfaces;

internal interface IPersonService
{
    IServiceResult AddPersonToList(IPerson person);
    IServiceResult DeletePersonFromList(IPerson person);
    IServiceResult ShowAllPersonsFromList();
    IServiceResult ShowOnePersonFromList(string email);
}