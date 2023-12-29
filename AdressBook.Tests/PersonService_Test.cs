using AdressBook.Interfaces;
using AdressBook.Models;
using AdressBook.Services;
using System.ComponentModel.DataAnnotations;

namespace AdressBook.Tests;

public class PersonService_Test //Behöver göra/kolla om interface innan fortsätter.
{
    [Fact]
    public void AddPersonShould_AddPersonToList_ThenReturnTrue()
    {
        //Arrange- Förberedelser
        
        Person person = new Person {FirstName="Åsa",LastName="W",Email="asa@domain.se",CityName="Gbg"};
        PersonService personService = new PersonService();


        //Act- vad ska hända
        personService.AddPersonToList(person);
        IEnumerable<Person> result = personService.GetAllPersons();
        
        //Assert-resultatet vi ska få
        Assert.NotEmpty(personService.GetAllPersons());
        Person returned_person = result.FirstOrDefault()!;
        Assert.NotNull(returned_person);
    }

    [Fact]
    public void RemovePersonShould_FindPersonInList_ThenRemovePersonFromList()
    {
        //Arrange
        PersonService personService = new PersonService();
        var personList = new Person();
        personList.Email = "asa@domain.se";


        //Act
        personService.DeletePersonFromList(personList, "asa@domain.se");
        IEnumerable<Person> result = personService.GetAllPersons();

        //Assert
        Assert.DoesNotContain(personList.ToString()!, personList.Email);
    }   


}
