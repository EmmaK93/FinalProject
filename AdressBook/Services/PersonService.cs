using AdressBook.Enums;
using AdressBook.Interfaces;
using AdressBook.Models;
using AdressBook.Models.Responses;
using System.Diagnostics;
using System.Linq;

namespace AdressBook.Services;

internal class PersonService : IPersonService
{
    private static readonly List<IPerson> _person = [];

 
        
    public IServiceResult AddPersonToList(IPerson person)
    {
        IServiceResult respons = new ServiceResult();
       
        try
        {
            if (!(_person.Any(X => X.Email == person.Email)))
            {
                _person.Add(person);
                Console.WriteLine("Person added to list");

                respons.Status = Enums.ResultStatus.SUCCEEDED;
                
                   
                
            }
            else
            {
                Console.WriteLine("E-mail adress already exists");

                respons.Status = Enums.ResultStatus.ALREADY_EXIST;

            }
                
            
            
        }
        catch (Exception ex) 
        {
            Debug.WriteLine(ex.Message); 
            respons.Status= Enums.ResultStatus.FAILED;
        }
        
        return respons;
    }

    public IServiceResult DeletePersonFromList(IPerson person)
    {
        IServiceResult respons = new ServiceResult();
        try
        {
            if (_person.Any(X => X.Email == person.Email))
            {
                _person.Remove(person);
                Console.WriteLine("Person removed from list.");
                respons.Status = Enums.ResultStatus.DELETED;
            }
            else
                Console.WriteLine("E-mail adress was not found.");
            respons.Status = Enums.ResultStatus.NOT_FOUND;

        }
        catch (Exception ex) 
        { 
            Debug.WriteLine(ex.Message);
            respons.Status = Enums.ResultStatus.FAILED;
        }
        return respons;

    }

    public IServiceResult ShowAllPersonsFromList()
    {
        IServiceResult respons = new ServiceResult();
        
        try
        {
            foreach (var item in _person)
            {
                respons.Status = Enums.ResultStatus.SUCCEEDED;
                respons.Result = _person;
            }
            
        }
        catch (Exception ex)
        { 
            Debug.WriteLine(ex.Message);
            respons.Status = Enums.ResultStatus.FAILED;
        }
        return respons;

    }

    public IServiceResult ShowOnePersonFromList(string email)
    {
        IServiceResult respons = new ServiceResult();
        try
        {     
            var person = new Person();
            if (_person.Any(X => X.Email == person.Email))
            {
                Console.WriteLine(person);
                respons.Status = Enums.ResultStatus.SUCCEEDED;
                
            }

            else
                Console.WriteLine("E-mail adress was not found.");
            respons.Status = Enums.ResultStatus.NOT_FOUND;
            
        }
        catch (Exception ex) 
        { 
            Debug.WriteLine(ex.Message);
            respons.Status = Enums.ResultStatus.FAILED;
        }
        return respons;
    }
}

