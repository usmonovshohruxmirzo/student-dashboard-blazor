using NET9.BlazorWebAppServerGlobal.Models;

namespace NET9.BlazorWebAppServerGlobal.Services;

public class StudentService
{
    private readonly List<Student> students = new()
    {
        new Student
        {
            Id = 1,
            FullName = "Alex Johnson",
            Gender = "Male",
            DateOfBirth = new DateOnly(2004, 6, 12),
            Gpa = 3.85m,
            Status = "Active",
            Subjects = new List<string> { "Math", "English", "Science" }
        },
        new Student
        {
            Id = 2,
            FullName = "Emily Clark",
            Gender = "Female",
            DateOfBirth = new DateOnly(2003, 11, 3),
            Gpa = 3.42m,
            Status = "Active",
            Subjects = new List<string> { "History", "Biology" }
        },
        new Student
        {
            Id = 3,
            FullName = "David Lee",
            Gender = "Male",
            DateOfBirth = new DateOnly(2004, 2, 19),
            Gpa = 2.98m,
            Status = "Inactive",
            Subjects = new List<string> { "Physics", "Chemistry" }
        }
    };

    public IReadOnlyList<Student> GetStudents() => students;

    public Student? GetStudentById(int id) => students.FirstOrDefault(student => student.Id == id);

    public void AddStudent(Student student)
    {
        var nextId = students.Count == 0 ? 1 : students.Max(student => student.Id) + 1;
        student.Id = nextId;
        student.Status = student.Gpa >= 2.0m ? "Active" : "Inactive";
        students.Add(student);
    }

    public void UpdateStudent(Student updatedStudent)
    {
        var existingStudent = students.FirstOrDefault(student => student.Id == updatedStudent.Id);
        if (existingStudent is null)
        {
            return;
        }

        existingStudent.FullName = updatedStudent.FullName;
        existingStudent.Gender = updatedStudent.Gender;
        existingStudent.DateOfBirth = updatedStudent.DateOfBirth;
        existingStudent.Gpa = updatedStudent.Gpa;
        existingStudent.Status = updatedStudent.Gpa >= 2.0m ? "Active" : "Inactive";
        existingStudent.Subjects = updatedStudent.Subjects;
    }

    public void DeleteStudent(int id)
    {
        var student = students.FirstOrDefault(item => item.Id == id);
        if (student is not null)
        {
            students.Remove(student);
        }
    }
}
