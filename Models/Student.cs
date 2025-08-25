namespace NET9.BlazorWebAppServerGlobal.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public double Gpa { get; set; }
        public List<string> Subjects { get; set; } = new();
        public string Status { get; set; } = "Active";
    }
}