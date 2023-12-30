using AdressBook.Models;
using AdressBook.Models.Responses;

namespace AdressBook.Interfaces;

public interface IPersonService
{
    /// <summary>
    /// Save contact to list if person with an email adress that doesnt exist n list
    /// </summary>
    /// <param name="person">Contains different variables that needs to be assigned</param>
    /// <returns>Result status message if the person was added</returns>
    IServiceResult AddPersonToList(Person person);

    /// <summary>
    /// Delete a person from list if the email adress exist and if the person exist in person list
    /// </summary>
    /// <param name="person">Contains different variables that needs to be assigned</param>
    /// <param name="email">Needs to contain an email from user input</param>
    /// <returns>Result status message if the person was found and deleted</returns>
    IServiceResult DeletePersonFromList(Person person, string email);

    /// <summary>
    /// Show all persons in list
    /// </summary>
    /// <returns>Returns all persons in list if the list isn't empty</returns>
    IServiceResult ShowAllPersonsFromList();

    /// <summary>
    /// Show one person if the email exist in the list
    /// </summary>
    /// <param name="email">Email must be input by user</param>
    /// <returns>person info with matching emailadress </returns>
    IServiceResult ShowOnePersonFromList(string email);
}