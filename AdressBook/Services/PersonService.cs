using AdressBook.Enums;
using AdressBook.Interfaces;
using AdressBook.Models;
using AdressBook.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;




namespace AdressBook.Services;

internal class PersonService : IPersonService
{
    private static List<IPerson> _personList= [];
    private readonly FileService _fileService = new FileService(@"C:\Education\CSharp\FinalProject\content.json");

 
        
    public IServiceResult AddPersonToList(IPerson person)
    {
        IServiceResult respons = new ServiceResult();
       
        try
        {
            if (!(_personList.Any(X => X.Email == person.Email)))
            {
                _personList.Add(person);

                _fileService.SaveContentToFile(JsonConvert.SerializeObject(_personList));

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
            if (_personList.Any(X => X.Email == person.Email))
            {
                _personList.Remove(person);
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
    public IEnumerable<IPerson> GetAllPersons()
    {
        IServiceResult respons = new ServiceResult();
        try
        {
            
            
            var content = _fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(content)) 
            {
                _personList = JsonConvert.DeserializeObject<List<IPerson>>(content)!;
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
        return _personList;
        

    }
    public IServiceResult ShowAllPersonsFromList()
    {
        IServiceResult respons = new ServiceResult();
        
        try
        {
            foreach (var item in _personList)
            {
                respons.Status = Enums.ResultStatus.SUCCEEDED;
                respons.Result = _personList;
            }
            
            GetAllPersons();
            
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
            var content = _fileService.GetContentFromFile();
            
            
            if ((!string.IsNullOrEmpty(content)))
            {
                _personList = JsonConvert.DeserializeObject<List<IPerson>>(content)!;
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

