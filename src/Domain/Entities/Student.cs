using StudentManagement.Domain.Enums;

namespace StudentManagement.Domain.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public decimal Gpa { get; set; }
    public StudentStatus Status { get; set; }
}
