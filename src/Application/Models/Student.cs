namespace NET9.BlazorWebAppServerGlobal.Models;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public decimal Gpa { get; set; }
    public string Status { get; set; } = "Active";
    public List<string> Subjects { get; set; } = new();
}
