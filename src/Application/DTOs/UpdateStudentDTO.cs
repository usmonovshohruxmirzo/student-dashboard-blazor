using StudentManagement.Domain.Enums;

namespace StudentManagement.Application.DTOs;

public sealed record UpdateStudentDto(
    string Name,
    Gender Gender,
    decimal Gpa,
    StudentStatus Status);
