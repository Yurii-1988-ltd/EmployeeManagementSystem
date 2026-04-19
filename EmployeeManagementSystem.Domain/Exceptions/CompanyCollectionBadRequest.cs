namespace EmployeeManagementSystem.Domain.Exceptions;

public  sealed class CompanyCollectionBadRequest : BadRequestException
{
    public CompanyCollectionBadRequest() : base("Company collection is null")
    {
    }
}