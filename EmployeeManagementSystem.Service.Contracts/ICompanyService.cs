using EmployeeManagementSystem.Shared.DTOs;

namespace EmployeeManagementSystem.Service.Contracts;

public interface ICompanyService
{
    IEnumerable<CompanyDto> GetAllCompaniesAsync(bool trackChanges);
    CompanyDto GetCompany(Guid companyId, bool trackChanges);
    CompanyDto CreateCompany(CompanyForCreationDto company);
    IEnumerable<CompanyDto> GetById(IEnumerable<Guid> ids, bool trackChanges);
}