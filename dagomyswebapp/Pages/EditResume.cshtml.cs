using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dagomyswebapp.Models;

namespace dagomyswebapp.Pages;

public class EditResumeModel : PageModel
{
    [BindProperty]
    public Student Resume { get; set; } = new();
    public IActionResult OnGet(int id)
    {
        var student = CreateResumeModel.Students.FirstOrDefault(s => s.id == id);
        if (student == null)
        {
            return NotFound();
        }
        Resume = new Student
        {
            id = student.id,
            First_Name = student.First_Name,
            Middle_Name = student.Middle_Name,
            Last_Name = student.Last_Name,
            Phone = student.Phone,
            Email = student.Email,
            BirthDate = student.BirthDate,
            City = student.City,
            Speciality = student.Speciality,
            StudyFormat = student.StudyFormat,
            Languages = student.Languages ?? new List<string>(),
            MainLanguage = student.MainLanguage,
            Technologies = student.Technologies ?? new List<string>(),
            About = student.About
        };
        return Page();
    }

    public IActionResult OnPost()
    {
        var student = CreateResumeModel.Students.FirstOrDefault(s => s.id == Resume.id);
        if (student == null)
        {
            return NotFound();
        }

        student.First_Name = Resume.First_Name;
        student.Middle_Name = Resume.Middle_Name;
        student.Last_Name = string.IsNullOrWhiteSpace(Resume.Last_Name) ? "-" : Resume.Last_Name;
        student.Phone = Resume.Phone;
        student.Email = Resume.Email;
        student.BirthDate = Resume.BirthDate;
        student.City = Resume.City;
        student.Speciality = Resume.Speciality;
        student.StudyFormat = Resume.StudyFormat;
        student.Languages = Resume.Languages ?? new List<string>();
        student.MainLanguage = Resume.MainLanguage;
        student.Technologies = Resume.Technologies ?? new List<string>();
        student.About = Resume.About;

        return RedirectToPage("/Resumes", new { Id = student.id });
    }
}