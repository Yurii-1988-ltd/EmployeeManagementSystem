
namespace EmployeeManagementSystem.Domain.Exceptions;

public sealed class IdParametersBadReqiuestException : BadRequestException
{
    public IdParametersBadReqiuestException() : base("Parameter ids is null")
    {
    }
}
