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

public class PersonService : IPersonService
{
    private static List<Person> _personList= []; //initerar lista för person-klass
    private readonly FileService _fileService = new FileService(@"C:\Education\CSharp\FinalProject\content.json"); //Initerar vart data ska lagras

 
        
    public IServiceResult AddPersonToList(Person person)
    {
        IServiceResult respons = new ServiceResult();
       
        try
        {
            if (!(_personList.Any(X => X.Email == person.Email)))
            {
                _personList.Add(person); //Lägger till person i lista

                _fileService.SaveContentToFile(JsonConvert.SerializeObject(_personList)); //Sparar lista till json-format

                respons.Status = Enums.ResultStatus.SUCCEEDED;
                
                   
                
            }
            else
            {
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

    public IServiceResult DeletePersonFromList(Person person, string email) 
    {
        IServiceResult respons = new ServiceResult();
        
        try
        {
            
            
            GetAllPersons();
            Person personToRemove = _personList.FirstOrDefault(x => x.Email == email)!;
            
            if (personToRemove != null)
            {
                _personList.Remove(personToRemove);
                respons.Status = Enums.ResultStatus.SUCCEEDED;
                _fileService.SaveContentToFile(JsonConvert.SerializeObject(_personList));

            }
            else if (!(_personList.Any(X => X.Email == person.Email)))
            {
                respons.Status = Enums.ResultStatus.NOT_FOUND;
            }


        }
        catch (Exception ex) 
        { 
            Debug.WriteLine(ex.Message);
            respons.Status = Enums.ResultStatus.FAILED;
        }
        return respons;

    }
    /* Vet att Hans i föreläsningen använde detta (IEnumerablelista) istället för att ha en metod som visade alla. I framtiden hade jag nog gjort detta med men använde den mer nu som en funktion för att kunna hämta listan och konvertera från json. Så funktionen borde skrivits om så det blir mer tydligt hur den används. */
    public IEnumerable<Person> GetAllPersons() //En lista som ej går att korrigera via programdelen.
    {
        IServiceResult respons = new ServiceResult();
        try
        {
            
            
            var content = _fileService.GetContentFromFile(); //hämtar listan
            if (!string.IsNullOrEmpty(content)) //Villkor om listan inte är tom
            {
                _personList = JsonConvert.DeserializeObject<List<Person>>(content)!; //Konverterar listan från json
                respons.Status = Enums.ResultStatus.SUCCEEDED;
            }
            else if (string.IsNullOrEmpty(content)) //Villkor om listan är tom
            {
                
                respons.Status = Enums.ResultStatus.NOT_FOUND; //Skickar tillbaka statuskod.
            }
            else
                respons.Status=Enums.ResultStatus.FAILED;
                

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
            GetAllPersons(); //Anropar listan för att konvertera från json
            foreach (var item in _personList) //Går igenom alla objekt i listan
            {
                respons.Status = Enums.ResultStatus.SUCCEEDED;
                respons.Result = _personList;

            }
            if (_personList.Count == 0) //villkor om listan är tom
            {
                respons.Status = Enums.ResultStatus.NOT_FOUND;
            }


        }
        catch (Exception ex)
        { 
            Debug.WriteLine(ex.Message);
            respons.Status = Enums.ResultStatus.FAILED;
        }
        return respons;

    }

    public IServiceResult ShowOnePersonFromList(string email) //Baserat på inkommande stringvärde
    {
        IServiceResult respons = new ServiceResult(); //initerar nytt serviceresult
        
        try
        {
            var content = _fileService.GetContentFromFile();

            GetAllPersons(); //Anropar listan för att konvertera från json

            
            foreach (Person person in _personList) //Loop som går igenom varje objekt i listan
            {

              
                if (_personList.Any(x=> x.Email == email)) //lambdafunktion som kollar om något objekt stämmer överens med stringvärdet.
                {
                    respons.Status=Enums.ResultStatus.SUCCEEDED; //skickar en statuskod till menuservice
                    respons.Result = _personList; //Skickar tillbaka listan till menuservice
                    

                }
                else if (!(_personList.Any(x => x.Email == email))) //Om listan ej innehåller ett objekt som stämmer överens med stringvärdet
                {
                    respons.Status = Enums.ResultStatus.NOT_FOUND;
                    
                    
                }

                else 
                {
                    Console.WriteLine("Gick in i else-sats"); //Kontrollkommentar för att följa programmet
                    respons.Status= Enums.ResultStatus.FAILED;
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

