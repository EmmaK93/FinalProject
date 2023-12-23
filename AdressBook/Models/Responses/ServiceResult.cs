using AdressBook.Enums;
using AdressBook.Interfaces;

namespace AdressBook.Models.Responses;
internal class ServiceResult : IServiceResult
{
    public ResultStatus Status {get; set; }
    public object Result { get; set; } = null!;
}
