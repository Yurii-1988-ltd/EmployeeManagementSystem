using EmployeeManagementSystem.Contracts;
using EmployeeManagementSystem.Service.Contracts;

namespace EmployeeManagementSystem.Service;

internal sealed class EmployeeService : IEmployeeService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    
    public EmployeeService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
    }
}