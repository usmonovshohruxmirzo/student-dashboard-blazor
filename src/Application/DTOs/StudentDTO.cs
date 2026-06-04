using StudentManagement.Domain.Enums;

namespace StudentManagement.Application.DTOs;

public sealed record StudentDto(
    int Id,
    string Name,
    Gender Gender,
    decimal Gpa,
    StudentStatus Status);
