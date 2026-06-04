using System.ComponentModel.DataAnnotations;
using StudentManagement.Domain.Enums;

public class CreateStudentDto
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Gender is required")]
    public Gender? Gender { get; set; }

    [Range(0, 4, ErrorMessage = "GPA must be between 0 and 4")]
    public decimal Gpa { get; set; }

    [Required(ErrorMessage = "Status is required")]
    public StudentStatus? Status { get; set; }
}
