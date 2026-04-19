using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Shared.DTOs;

public record EmployeeForUpdateDto
{
    [MaxLength(30,ErrorMessage = "Name cannot exceed 30 characters")]
    public string? Name { get; init; }

    [Range(18,int.MaxValue, ErrorMessage = "Age is required and it cannot be lower than 18")]
    public int Age { get; init; }

    [Required(ErrorMessage = "Position is required")]
    [MaxLength(20,ErrorMessage = "Position cannot exceed 20 characters")]
    public string Position { get; init; }
}
