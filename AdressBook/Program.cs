using AdressBook.Interfaces;
using AdressBook.Models;
using AdressBook.Services;
using Newtonsoft.Json;
using System.Text.Json;

IMenuService menuService = new MenuService(); //Initerar Menuservice

menuService.MainMenu(); //Anropar metoden MainMenu