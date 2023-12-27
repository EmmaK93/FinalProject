using AdressBook.Interfaces;
using AdressBook.Models;
using System;
using System.Runtime.CompilerServices;

namespace AdressBook.Services;

internal class MenuService : IMenuService
{
    private readonly IPersonService _personService = new PersonService();
    private readonly Person _person = new Person();
    
    
    internal void TitleMenu(string Title)
    {
        Console.Clear();
        Console.WriteLine($"###{Title}###");
        Console.WriteLine("");
    }

    internal void PressAnyKey()
    {
        Console.WriteLine();
        Console.WriteLine("Press Any key to continue!");
        Console.ReadKey();
    }

    public void MainMenu() //meny med val som går vidare till aktuell meny
    {
        while (true)
        {
            TitleMenu("Main Menu");
            Console.WriteLine($"{"1.",-3}Add new person to list.");
            Console.WriteLine($"{"2.",-3}Remove person from list.");
            Console.WriteLine($"{"3.",-3}Show one person from list.");
            Console.WriteLine($"{"4.",-3}Show all persons from list.");
            Console.WriteLine($"{"Q.",-3}Exit application.");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddMenu();
                    break;
                case "2":
                    RemoveMenu();
                    break;
                case "3":
                    ShowOneMenu();
                    break;
                case "4":
                    ShowAllMenu();
                    break;
                case "q" or "Q":
                    ExitProgram();
                    break;
            }
            
            
        }
        


    }
    private void AddMenu()
    {
        Person person = new Person();
        

        TitleMenu("Add person to list");
        //insamling av data för att lägga till ny person.

        Console.WriteLine("First name:");
        person.FirstName = Console.ReadLine()!;

        Console.WriteLine("\nLast name:");
        person.LastName = Console.ReadLine()!;

        Console.WriteLine("\nE-mail:");
        person.Email = Console.ReadLine()!; 
        //Konverterar console readline så att det kan lagras som stringvärde.
        Console.WriteLine("\nPhone number:");
        string input = Console.ReadLine()!;
        if(int.TryParse(input, out int number)) //Använder tryParse för att inte systemet ska krascha.
        {
            person.PhoneNumber = number;
        }
        else
        {
            person.PhoneNumber = null!;
        }
        Console.WriteLine("\nStreet name:");
        person.StreetName = Console.ReadLine()!;

        //testade med bool-värde istället
        Console.WriteLine("\nPostal code:");
        bool _postal = int.TryParse(Console.ReadLine()!, out int _postalConvert);
        if (_postal == true) 
        {
            // var postal= _postal.ToString();
            person.PostalCode = _postalConvert;
        }
        else
        {
             person.PostalCode = null!;
        }
        Console.WriteLine("\nCity name:");
        person.CityName = Console.ReadLine()!;

        var result = _personService.AddPersonToList(person); //skickar resultat till metod i personService

        switch (result.Status) //Meny efter statuskod i metod i personservice
        {
            case Enums.ResultStatus.SUCCEEDED:
                Console.WriteLine("##Added to list!##");
                break;
            case Enums.ResultStatus.FAILED:
                Console.WriteLine("##Failed to add to list##");
                Console.WriteLine("See error message ::" + result.Result.ToString());
                break;
            case Enums.ResultStatus.ALREADY_EXIST: 
                Console.WriteLine("##Person already exist##");
                break;
            default:
                Console.WriteLine("##Something went wrong, try again!##");
                break;
        }
        PressAnyKey();

    }

    private void RemoveMenu()
    {
        
        TitleMenu("Remove a person from list");
        Console.Write("Enter E-mail:");
        string email = Console.ReadLine()!;
        var result = _personService.DeletePersonFromList(_person, email); //skickar lista samt input till metod i personService

        switch (result.Status)
        {
            case Enums.ResultStatus.SUCCEEDED:
                Console.WriteLine("##Person removed from list##");
                               
                break;
            case Enums.ResultStatus.FAILED:
                Console.WriteLine("##Failed##");
                
                break;
            case Enums.ResultStatus.NOT_FOUND:
                Console.WriteLine("##Person does not exist##");
                
                break;
            default:
                Console.WriteLine("##Something went wrong, try again!##");
                
                break;
        }



        PressAnyKey();

    }

    private void ShowOneMenu()
    {
        TitleMenu("Find person");
        Console.WriteLine("Write email");
        var email = Console.ReadLine()!;
        
        
        var result = _personService.ShowOnePersonFromList(email);

        switch (result.Status)
        {
            case Enums.ResultStatus.SUCCEEDED:
                //if-sats för att skriva ut information om personen
                if (result.Result is List<Person> personList)
                {
                    Person person = personList.Find(x => x.Email == email)!; 
                    
                    Console.WriteLine("##Person found##");
                    Console.WriteLine("---------------------");
                    Console.WriteLine($"{person.FirstName}"+" "+$"{person.LastName}\n{person.Email}\n{person.PhoneNumber}\n{person.StreetName}\n{person.PostalCode}"+" "+$"{person.CityName}");
                     
                }
                break;
            case Enums.ResultStatus.FAILED:
                Console.WriteLine("##Failed##");
              
                break;
            case Enums.ResultStatus.ALREADY_EXIST:
                Console.WriteLine("##Person already exist##");
               
                break;
            case Enums.ResultStatus.NOT_FOUND:
                Console.WriteLine("##Email does not exist##");
                break;

            default:
                Console.WriteLine("##Something went wrong, try again!##");
                
                break;
        }
        

        PressAnyKey();

    }

    private void ShowAllMenu() 
    {
        TitleMenu("Show all persons on list");

        var result = _personService.ShowAllPersonsFromList();
        if (result.Status == Enums.ResultStatus.SUCCEEDED)
        {
            if (result.Result is List<Person> personList) 
            {
                foreach (var person in personList)
                {
                    Console.WriteLine($"{person.FirstName}" + " " + $"{person.LastName}\n{person.Email}\n{person.PhoneNumber}\n{person.StreetName}\n{person.PostalCode}" + " " + $"{person.CityName}");
                }
            }
            
        }
        else if (result.Status == Enums.ResultStatus.NOT_FOUND)
        {
            Console.WriteLine("Ingen lista hittades");
        }

        PressAnyKey();
    }

    private void ExitProgram()
    {
        TitleMenu("Exit program");
        Console.WriteLine("Are you sure you want to exit program? y/n");
        var input = Console.ReadLine()!;

        switch (input)
        {
            case "y" or "Y":
                Environment.Exit(0);
                break;

            case "n" or "N":
                MainMenu();
                break;
        }

        PressAnyKey();
    }
}
