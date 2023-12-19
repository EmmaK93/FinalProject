using AdressBook.Interfaces;
using AdressBook.Models;
using System;
using System.Diagnostics;

namespace AdressBook.Services;

internal class PersonService : IPersonService
{
    private readonly FileService _fileService = new FileService();
    private List<Persons> _personsList = new List<Persons>();
    
    public void AddPersons(Persons person)
    {
        try
        {
            if (! _personsList.Any(X => X.Email == person.Email))
            {
                _personsList.Add(person);
                
                //_fileService.SaveCntentToFile(JsonConvert.SerializeObject(_personsList));
                //Måste installera Jsonprogrammet (Kommer lysa rött)

            }
            
            
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message.ToString());
        }

        
    }
    // SKapar en lista som enbart går att läsa, ej redigera
    public IEnumerable<Persons> GetAllPersons() 
    {
        try
        {

            //var content = FileService.GetContentFromFile(); Ej skapat GetContentFromFile än
                
            // if (!string.isNullOrEmpty(content)){
            //_personList= JsonConvert.DeserializeObject<List<Persons>>(content)!;}
                
            


        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message.ToString());
        }
        return _personsList;

    }

    public bool RemovePersons()
    {
        try
        {
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message.ToString());
        }

        return true;
    }

    public void ShowAllPersons()
    {
        try
        {
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message.ToString());
        }

        return;
    }

    public void ShowOnePerson()
    {
        try
        {
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message.ToString());
        }

        return;
    }
}
