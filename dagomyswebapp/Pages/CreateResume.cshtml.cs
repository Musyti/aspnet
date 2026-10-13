using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dagomyswebapp.Models;

namespace dagomyswebapp.Pages;

public class CreateResumeModel : PageModel
{
    [BindProperty]
    public string First_Name { get; set; } = "";

    [BindProperty]
    public string Middle_Name { get; set; } = "";

    [BindProperty]
    public string? Last_Name { get; set; }

    [BindProperty]
    public string Phone { get; set; } = "";

    [BindProperty]
    public string Email { get; set; } = "";

    [BindProperty]
    public DateTime? BirthDate { get; set; }

    [BindProperty]
    public string? City { get; set; }

    [BindProperty]
    public string? Speciality { get; set; }

    [BindProperty]
    public string? StudyFormat { get; set; }

    [BindProperty]
    public List<string> Languages { get; set; } = new();

    [BindProperty]
    public string? MainLanguage { get; set; }

    [BindProperty]
    public List<string> Technologies { get; set; } = new();

    [BindProperty]
    public string? About { get; set; }

    // Статический список студентов, к которому обращается Resumes.cshtml.cs
    public static List<Student> Students { get; set; } = new();

    public string? Message { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        Last_Name = string.IsNullOrWhiteSpace(Last_Name) ? "-" : Last_Name;

        var student = new Student
        {
            // Если в вашей модели Student свойство называется Id с большой буквы, укажите Id
            id = Students.Any() ? Students.Max(x => x.id) + 1 : 1,
            First_Name = First_Name,
            Middle_Name = Middle_Name,
            Last_Name = Last_Name,
            Phone = Phone,
            Email = Email,
            BirthDate = BirthDate,
            City = City,
            Speciality = Speciality,
            StudyFormat = StudyFormat,
            Languages = Languages,
            MainLanguage = MainLanguage,
            Technologies = Technologies,
            About = About
        };

        Students.Add(student);

        return new JsonResult(student);
    }

    public IActionResult OnGetStudents()
    {
        return new JsonResult(Students);
    }

    public IActionResult OnPostDelete(int id)
    {
        var student = Students.FirstOrDefault(x => x.id == id);
        if (student == null)
        {
            return new JsonResult(new
            {
                success = false,
                message = "Студент не найден"
            });
        }

        Students.Remove(student);

        return new JsonResult(new
        {
            success = true
        });
    }
}