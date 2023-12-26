using AdressBook.Enums;
using AdressBook.Interfaces;
using AdressBook.Models;
using AdressBook.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;




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

    public IServiceResult DeletePersonFromList(string email)
    {
        IServiceResult respons = new ServiceResult();
        
        try
        {
            var content = _fileService.GetContentFromFile();

            GetAllPersons();

            bool removed = false;
            for (int i = 0; i < _personList.Count; i++)
            {
                if (_personList[i].Email == email)
                {
                    _personList.RemoveAt(i);
                    Console.WriteLine("Personen har tagits bort från adressboken.");
                    removed = true;
                }
                if (!removed)
                {
                    Console.WriteLine("Det finns ingen person med den mejladressen i adressboken.");
                }
            }


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
                Console.WriteLine("The list is empty");
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
            GetAllPersons();
            foreach (var item in _personList)
            {
                respons.Status = Enums.ResultStatus.SUCCEEDED;
                respons.Result = _personList;
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
            var content = _fileService.GetContentFromFile();

            GetAllPersons();

            bool personToFind = false;
            foreach (Person person in _personList)
            {
                if (person.Email == email)
                {

                    respons.Result = _personList;
                    personToFind = true;
                }
                if (!personToFind)
                {
                    Console.WriteLine("Det finns ingen person med den mejladressen i adressboken.");
                }

            }
                

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            respons.Status = Enums.ResultStatus.FAILED;
        }
        return respons;
    }
}

