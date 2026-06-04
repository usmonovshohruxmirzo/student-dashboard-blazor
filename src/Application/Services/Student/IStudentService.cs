using StudentManagement.Application.DTOs;

namespace StudentManagement.Application.Interfaces;

public interface IStudentService
{
    Task<List<StudentDto>> GetAllAsync(CancellationToken ct = default);
    Task<StudentDto?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<StudentDto> CreateAsync(CreateStudentDto dto, CancellationToken ct = default);
    Task<bool> UpdateAsync(int id, UpdateStudentDto dto, CancellationToken ct = default);
    Task<bool> DeleteAsync(int id, CancellationToken ct = default);
}
