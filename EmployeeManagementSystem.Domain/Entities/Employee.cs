using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Domain.Entities;

public sealed class Employee
{
    [Column("EmployeeId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Employee name is required fields")]
    [MaxLength(30, ErrorMessage = "Maximum length for the name is 30 characters")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Employee position is required fields")]
    [MaxLength(20, ErrorMessage = "Maximum length for the position is 20 characters")]
    public string? Position { get; set; }
    
    // Navigation properties
    [ForeignKey(nameof(Company))]
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
    
}