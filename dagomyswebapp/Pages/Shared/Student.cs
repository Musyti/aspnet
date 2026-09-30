namespace dagomyswebapp.Models;

public class Student
{
    public int id {get; set;}
    public string First_Name { get; set; } = "";
    public string Middle_Name { get; set; } = "";
    public string? Last_Name { get; set; }
    public string Phone { get; set; } = "";
    public string Email { get; set; } = "";
    public DateTime? BirthDate { get; set; }
    public string? City { get; set; }
    public string? Speciality { get; set; }
    public string? StudyFormat { get; set; }
    public List<string> Languages { get; set; } = new();
    public string? MainLanguage { get; set; }    
    public List<string> Technologies { get; set; } = new();
    public string? About { get; set; }
    

}