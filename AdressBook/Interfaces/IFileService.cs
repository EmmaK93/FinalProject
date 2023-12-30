namespace AdressBook.Interfaces;

public interface IFileService
{
    /// <summary>
    /// An method of streamwriter for saving content to file 
    /// </summary>
    /// <param name="content">String value of the file/list that can be converted to json</param>
    /// <returns>True or false if it could save content</returns>
    bool SaveContentToFile(string content);

    /// <summary>
    /// Collects saved data (list of persons) from file with streamreader.
    /// </summary>
    /// <returns>The text of the saved file</returns>
    string GetContentFromFile();
}
