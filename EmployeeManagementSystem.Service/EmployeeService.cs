using AutoMapper;
using EmployeeManagementSystem.Contracts;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Exceptions;
using EmployeeManagementSystem.Service.Contracts;
using EmployeeManagementSystem.Shared.DTOs;

namespace EmployeeManagementSystem.Service;

internal sealed class EmployeeService : IEmployeeService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;
    
    public EmployeeService(IRepositoryManager repositoryManager, ILoggerManager loggerManager,IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }

    public IEnumerable<EmployeeDto> GetAllEmployeesAsync(Guid companyId, bool trackChanges)
    {
        var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);
        var employeeFromDb = _repositoryManager.Employee.GetAllEmployeesAsync(companyId, trackChanges);
        return _mapper.Map<IEnumerable<EmployeeDto>>(employeeFromDb);

    }

    public EmployeeDto GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges)
    {
        var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);
        var employeeFromDb = _repositoryManager.Employee.GetEmployeeAsync(companyId, id, trackChanges);
        if (employeeFromDb is null)
            throw new EmployeeNotFoundException(id);
        return _mapper.Map<EmployeeDto>(employeeFromDb);
    }

    public CompanyDto CreateCompanyAsync(CompanyForCreationDto companyForCreationDto)
    {
        var companyEntity = _mapper.Map<Company>(companyForCreationDto);
        _repositoryManager.Company.CreateCompany(companyEntity);
        _repositoryManager.Save();
        return _mapper.Map<CompanyDto>(companyEntity);
    }

    public EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto creationEmployeeDto, bool trackChanges)
    {
        var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if(company is null)
            throw new CompanyNotFoundException(companyId);
        var employeeEntity = _mapper.Map<Employee>(creationEmployeeDto);
        _repositoryManager.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
        _repositoryManager.Save();
        return _mapper.Map<EmployeeDto>(employeeEntity);
    }
}