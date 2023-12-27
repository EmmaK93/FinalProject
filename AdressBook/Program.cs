using AdressBook.Interfaces;
using AdressBook.Models;
using AdressBook.Services;
using Newtonsoft.Json;
using System.Text.Json;

//var contentFile = new FileService(@"C:\Education\CSharp\FinalProject\content.json");

IMenuService menuService = new MenuService();

menuService.MainMenu();