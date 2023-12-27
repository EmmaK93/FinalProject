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
        personService.AddPersonToList(person);


        //Act- vad ska hända
        IEnumerable<Person> result = personService.GetAllPersons();
        
        //Assert-resultatet vi ska få
        Assert.NotEmpty(personService.GetAllPersons());
        Person returned_person = result.FirstOrDefault()!;
        Assert.NotNull(returned_person);
    }



}
