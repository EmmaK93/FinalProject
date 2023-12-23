using AdressBook.Enums;

namespace AdressBook.Interfaces;

public interface IServiceResult
{
    ResultStatus Status { get; set; }
    object Result { get; set; }
}
