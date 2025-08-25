using NET9.BlazorWebAppServerGlobal.Models;
using System.Collections.Generic;
using System.Linq;

namespace NET9.BlazorWebAppServerGlobal.Services
{
    public class StudentService
    {
        private readonly List<Student> students = new List<Student>
        {
            new Student { Id = 1, FullName = "Alex", Gender = "Male", Gpa = 3.15, Status = "Active" },
            new Student { Id = 2, FullName = "Diana", Gender = "Female", Gpa = 3.82, Status = "Active" }
        };

        public List<Student> GetStudents() => students;

        public void AddStudent(Student student)
        {
            student.Id = students.Count > 0 ? students.Max(s => s.Id) + 1 : 1;
            students.Add(student);
        }

        public void DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null) students.Remove(student);
        }
    }
}
