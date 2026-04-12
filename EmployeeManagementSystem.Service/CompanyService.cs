using EmployeeManagementSystem.Contracts;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Service.Contracts;

namespace EmployeeManagementSystem.Service;
internal sealed class CompanyService : ICompanyService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;

    public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
    }

    public IEnumerable<Company> GetAllCompaniesAsync(bool trackChanges)
    {
        try
        {
            var companies = _repositoryManager.Company.GetAllCompaniesAsync(trackChanges);
            return companies;

        }
        catch (Exception e)
        {
            _loggerManager.LogError($"Something went wrong {nameof(GetAllCompaniesAsync)} service method {e}");
            throw;
        }
    }
}