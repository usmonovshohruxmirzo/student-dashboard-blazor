using Microsoft.AspNetCore.Mvc;
using StudentManagement.Application.DTOs;
using StudentManagement.Application.Interfaces;

namespace StudentManagement.Presentation.Controllers;

[ApiController]
[Tags("Students")]
[Route("api/v1/[controller]")]
public sealed class StudentsController : ControllerBase
{
  private readonly IStudentService _service;

  public StudentsController(IStudentService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll(CancellationToken ct)
  {
    return Ok(await _service.GetAllAsync(ct));
  }

  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetById(int id, CancellationToken ct)
  {
    var student = await _service.GetByIdAsync(id, ct);
    return student is null ? NotFound() : Ok(student);
  }

  [HttpPost]
  public async Task<IActionResult> Create(CreateStudentDto dto, CancellationToken ct)
  {
    var created = await _service.CreateAsync(dto, ct);
    return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update(int id, UpdateStudentDto dto, CancellationToken ct)
  {
    var result = await _service.UpdateAsync(id, dto, ct);
    return result ? NoContent() : NotFound();
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete(int id, CancellationToken ct)
  {
    var result = await _service.DeleteAsync(id, ct);
    return result ? NoContent() : NotFound();
  }
}
