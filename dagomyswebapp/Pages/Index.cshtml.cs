using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dagomyswebapp.Models;

namespace dagomyswebapp.Pages;

public class IndexModel : PageModel
{
    public string? Message { get; set; }

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
    public List<Student> Students {get; set;} = new();
    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        Last_Name = string.IsNullOrWhiteSpace(Last_Name) ? "-" : Last_Name;

        // string message =
        //     $"Имя: {First_Name}\n" +
        //     $"Фамилия: {Middle_Name}\n" +
        //     $"Отчество: {Last_Name}\n" +
        //     $"Номер телефона: {Phone}\n" +
        //     $"Адрес электронной почты: {Email}\n" +
        //     $"Дата рождения: {(BirthDate.HasValue ? BirthDate.Value.ToString("dd.MM.yyyy") : "-")}\n" +
        //     $"Город: {City ?? "-"}\n" +
        //     $"Специальность: {Speciality ?? "-"}\n" +
        //     $"Формат обучения: {StudyFormat ?? "-"}\n" +
        //     $"Языки программирования: {(Languages.Count > 0 ? string.Join(", ", Languages) : "-")}\n" +
        //     $"Основной язык: {MainLanguage ?? "-"}\n" +
        //     $"Технологии: {(Technologies.Count > 0 ? string.Join(", ", Technologies) : "-")}\n" +
        //     $"О себе: {About ?? "-"}";

        var student = new Student{
            id = Students.Count + 1,
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

    public IActionResult OnPostDelete(int Id)
    {
        var student = Students.FirstOrDefault(x => x.id == Id);
        if (student == null)
        {
            return new JsonResult(new
            {
                success = false,
                message = "Студент не найден"
            });
        }
        Students.Remove(student);
        return new JsonResult (new
        {
           success = true 
        });
    }
}
