using StudentManagement.Domain.Enums;

namespace StudentManagement.Application.DTOs;

public sealed record CreateStudentDto(
    string Name,
    Gender Gender,
    decimal Gpa,
    StudentStatus Status);
