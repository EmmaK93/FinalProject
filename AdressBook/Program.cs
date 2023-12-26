using AdressBook.Interfaces;
using AdressBook.Services;

var PersonService = new PersonService();
var list = PersonService.GetAllPersons();

IMenuService menuService = new MenuService();

menuService.MainMenu();