using AdressBook.Interfaces;
using AdressBook.Services;

namespace AdressBook.Tests;

public class FileService_test
{
    [Fact]

    public void SaveToFileShould_SaveContentToFile_ThenReturnTrue()
    {
        //Arrange
        string filePath = @"C:\Education\CSharp\FinalProject\Test.json";
        IFileService fileService = new FileService(filePath);
        string content = "Test content";


        
        //Act
        bool result = fileService.SaveContentToFile(content);
        
        
        //Assert
        Assert.True(result);
    }
}
