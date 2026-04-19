using EmployeeManagementSystem.Service.Contracts;
using EmployeeManagementSystem.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Presentation.Controllers;

[ApiController]
[Route("api/companies/{companyId}/employees")]
public class EmployeeController: ControllerBase
{
    private readonly IServiceManager _services;
	public EmployeeController(IServiceManager services)=>_services = services;

	[HttpGet]
	public IActionResult GetAllEmployeesForCompany(Guid companyId)
	{
		var employees = _services.EmployeeService.GetAllEmployeesAsync(companyId, false);
		return Ok(employees);
	}
	[HttpGet("{id:guid}")]
	public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
	{
		var employee = _services.EmployeeService.GetEmployeeAsync(companyId, id, false);
		return Ok(employee);
	}
	[HttpPost]
	public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody]EmployeeForCreationDto employee)
	{
		if (employee is null)
			return BadRequest("EmployeeForCreationDto object is null");
		var employeeToReturn = _services.EmployeeService.CreateEmployeeForCompany(companyId, employee, false);
		return CreatedAtRoute("GetEmployeeForCompany", new { companyId, id = employeeToReturn.Id }, employeeToReturn);

    }
	[HttpDelete("{id:guid}")]
	public IActionResult DeleteEmployeeForCompany(Guid companyId, Guid id)
	{
		_services.EmployeeService.DeleteEmployeeForCompany(companyId, id, false);
		return NoContent();
	}

	[HttpPut("{id:guid}")]
	public IActionResult UpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] EmployeeForUpdateDto employee)
	{
		if (employee is null)
		{
			return BadRequest("Employee object is null ");
		}

		if (!ModelState.IsValid)
			return UnprocessableEntity(ModelState);
		
		_services.EmployeeService.UpdateEmployeeForCompany(companyId, id, employee, companyTrackChanges: false, employeeTrackChanges: true);
		
		return NoContent();
	}

}
