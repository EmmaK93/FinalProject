using AdressBook.Interfaces;

namespace AdressBook.Models;

//Metoder/Layout för de olika menyvalen
internal class MenuOptions : IMenuOption
{
    // Ett fält som kopplar IPersonService: PersonService som innehåller metoderna för funktioner i programmet.
     private readonly IPersonService _personService = new PersonService();
     
    
    public void MenuTitle(string Title)
    {
        Console.Clear();
        Console.WriteLine($"##{Title}##");
        Console.WriteLine();
        
    }
    public void MainMenuOption()
    {
        MenuTitle("Main menu");
        Console.WriteLine("Choose one of the options below:");
        Console.WriteLine($"1.Add new person to list");
        Console.WriteLine($"2.Remove person from list");
        Console.WriteLine($"3.Show all persons on list");
        Console.WriteLine($"4.Show one person from list");
        Console.WriteLine($"0.Exit aplication");

        var option = Console.ReadLine();

        switch ( option )
        {
            case "1":
                AddPersonMenu();
                break;
            case "2":
                RemovePersonMenu();
                break;
            case "3":
                ShowAllMenu();
                break;
            case "4":
                ShowOneMenu();
                break;
            case "0":
                ExitApplication();
                break;
        }
    }

    private void AddPersonMenu()
    {
        var person = new Persons();
        MenuTitle("Add Person to the list");
        Console.WriteLine("Fill in the information below:");
        Console.Write("First name:");
        person.FirstName = Console.ReadLine()!;
        Console.Write("Last name:");
        person.LastName = Console.ReadLine()!;
        Console.Write("Street name:");
        person.StreetName = Console.ReadLine()!;
        Console.Write("City:");
        person.CityName = Console.ReadLine()!;
        Console.Write("E-mail adress:");
        person.Email = Console.ReadLine()!;

        if (person.Equals(person.Email))
        {
            var input = _personService.AddPersons();
        }

        
    }
    private void RemovePersonMenu()
    {
        var person = new Persons();
        MenuTitle("Remove person from list");


        var result = _personService.RemovePersons();

    }
    private void ShowAllMenu()
    {
        MenuTitle("Show All");
    }
    private void ShowOneMenu()
    {
        MenuTitle("Show one person");
    }

    private void ExitApplication()
    {
        Console.WriteLine("Are you sure you want to exit the program? y/n");
        var option = Console.ReadLine();

        if (option == "y")
        {
            Environment.Exit(0);
        }
        else
        {
            MainMenuOption();
        }
    }


    
    

}