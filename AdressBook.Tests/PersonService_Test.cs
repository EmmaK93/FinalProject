using AdressBook.Interfaces;
using AdressBook.Models;
using AdressBook.Services;

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
        var result = personService.AddPersonToList(person);
        
        //Assert-resultatet vi ska få
        Assert.NotEmpty(personService.GetAllPersons());
        Assert.True(((IEnumerable<Person>)result).Any());
    }



}
