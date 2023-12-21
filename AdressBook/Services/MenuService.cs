using AdressBook.Interfaces;
using AdressBook.Models;
using System.Runtime.CompilerServices;

namespace AdressBook.Services;

internal class MenuService
{
    internal void TitleMenu(string Title)
    {
        Console.Clear();
        Console.WriteLine($"###{Title}###");
        Console.WriteLine("");
    }

    public void MainMenu()
    {
        TitleMenu("Main Menu");
        Console.WriteLine("1.Add new person to list.");
        Console.WriteLine("2.Remove person from list.");
        Console.WriteLine("3.Show one person from list.");
        Console.WriteLine("4.Show all persons from list.");
        Console.WriteLine("Q.Exit application.");

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
            case "q || Q":
                break;
        }


    }
    private void AddMenu()
    {
        var person = new Person();

        TitleMenu("Add person to list");


        Console.WriteLine("First name:");
        person.FirstName = Console.ReadLine()!;
        Console.WriteLine("Last name:");
        person.LastName = Console.ReadLine()!;
        Console.WriteLine("E-mail:");
        person.Contact.Email = Console.ReadLine()!; //Funkar ej
        /*
         * Detta felmeddelande uppstår när du försöker använda en nullreferens eller variabel. 
         * Det kan orsakas av att den är inställd på null, passerad som parameter eller att dess medlemmar används. 
         * För att lösa felet kan du kontrollera referensen, initialisera den eller använda nullable variabler. 
         * Se exempel, orsaker och lösningar från 22 svar på Stack Overflow 1.
         * En nullreferens innebär att en variabel inte pekar på något objekt i minnet. 
         * När du försöker använda en nullreferens i din kod, kommer en System.NullReferenceException att kastas. 
         * Felet uppstår vanligtvis när du försöker använda en variabel som inte har tilldelats något värde eller när du försöker använda en variabel som har tilldelats värdet null 1.
         
         */
        Console.WriteLine("Phone number:");
        person.Contact.PhoneNumber = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Street name:");
        person.Adress.StreetName = Console.ReadLine()!;
        Console.WriteLine("Postal code:");
        person.Adress.PostalCode = int.Parse(Console.ReadLine()!);
        Console.WriteLine("City name:");
        person.Adress.CityName = Console.ReadLine()!;

        Console.ReadKey();

    }

    private void RemoveMenu()
    {

    }

    private void ShowOneMenu()
    {

    }

    private void ShowAllMenu() 
    {
    
    }
}
