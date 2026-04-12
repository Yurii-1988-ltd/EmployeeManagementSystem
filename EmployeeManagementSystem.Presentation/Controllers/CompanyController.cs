using EmployeeManagementSystem.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController: ControllerBase
{
    private readonly IServiceManager _service;

    public CompanyController(IServiceManager companyService)=>_service = companyService;
    
    [HttpGet]
    public IActionResult GetAllCompanies()
    {
        try
        {
            var companies = _service.CompanyService.GetAllCompaniesAsync(false);
            return Ok(companies);

        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal Server Error");
        }
        
    }
}