using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dagomyswebapp.Models;

namespace dagomyswebapp.Pages;

public class ResumeModel : PageModel
{
    public Student? Resume { get; set; }
    public IActionResult OnGet(int id)
    {
        Resume = CreateResumeModel.Students
        .FirstOrDefault(student => student.id == id);
        if (Resume == null)
        {
            return NotFound();
        }
        return Page();
    }
}