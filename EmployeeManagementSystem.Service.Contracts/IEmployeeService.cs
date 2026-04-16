using EmployeeManagementSystem.Shared.DTOs;

namespace EmployeeManagementSystem.Service.Contracts;

public interface IEmployeeService
{
    IEnumerable<EmployeeDto> GetAllEmployeesAsync(Guid companyId, bool trackChanges);
    EmployeeDto GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);
    CompanyDto CreateCompanyAsync(CompanyForCreationDto companyForCreationDto);
    EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto creationEmployeeDto,
        bool trackChanges);
}