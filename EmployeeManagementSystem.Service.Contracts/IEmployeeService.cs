using EmployeeManagementSystem.Shared.DTOs;

namespace EmployeeManagementSystem.Service.Contracts;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync(Guid companyId, bool trackChanges);
    Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);
    Task<EmployeeDto> CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeForCreationDto, bool trackChanges);
    Task DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackChanges);
    Task UpdateEmployeeForCompany(Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdateDto,
        bool companyTrackChanges, bool employeeTrackChanges);
}