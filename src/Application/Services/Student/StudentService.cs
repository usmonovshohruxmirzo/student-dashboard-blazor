using StudentManagement.Application.DTOs;
using StudentManagement.Application.Interfaces;
using StudentManagement.Domain.Entities;
using StudentManagement.Domain.Interfaces;

namespace StudentManagement.Application.Services;

public sealed class StudentService : IStudentService
{
  private readonly IRepository<Student, int> _repository;

  public StudentService(IRepository<Student, int> repository)
  {
    _repository = repository;
  }

  public async Task<List<StudentDto>> GetAllAsync(CancellationToken ct = default)
  {
    var students = await _repository.GetAllAsync(ct);

    return [.. students.Select(Map)];
  }

  public async Task<StudentDto?> GetByIdAsync(int id, CancellationToken ct = default)
  {
    var student = await _repository.GetByIdAsync(id, ct);

    return student is null ? null : Map(student);
  }

  public async Task<StudentDto> CreateAsync(CreateStudentDto dto, CancellationToken ct = default)
  {
    if (dto.Gender is null)
      throw new ArgumentException("Gender is required");

    if (dto.Status is null)
      throw new ArgumentException("Status is required");

    var student = new Student
    {
      Name = dto.Name.Trim(),
      Gender = dto.Gender.Value,
      Gpa = dto.Gpa,
      Status = dto.Status.Value
    };

    await _repository.AddAsync(student, ct);
    await _repository.SaveChangesAsync(ct);

    return Map(student);
  }

  public async Task<bool> UpdateAsync(int id, UpdateStudentDto dto, CancellationToken ct = default)
  {
    var student = await _repository.GetByIdAsync(id, ct);

    if (student is null)
      return false;

    student.Name = dto.Name.Trim();
    student.Gender = dto.Gender;
    student.Gpa = dto.Gpa;
    student.Status = dto.Status;

    _repository.Update(student);
    await _repository.SaveChangesAsync(ct);

    return true;
  }

  public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
  {
    var student = await _repository.GetByIdAsync(id, ct);

    if (student is null)
      return false;

    _repository.Remove(student);
    await _repository.SaveChangesAsync(ct);

    return true;
  }

  private static StudentDto Map(Student s)
  {
    return new StudentDto(
        s.Id,
        s.Name,
        s.Gender,
        s.Gpa,
        s.Status
    );
  }
}
