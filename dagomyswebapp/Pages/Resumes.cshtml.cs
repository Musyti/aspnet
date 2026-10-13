using dagomyswebapp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dagomyswebapp.Pages;

public class ResumesModel : PageModel
{
    public List<Student> Students { get; set; } = new();
    public void OnGet()
    {
        Students = CreateResumeModel.Students;
    }
   
}
