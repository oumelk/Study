using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Study.Core;
using Study.Data;

namespace Study.Pages.Students
{
    public class DetailModel : PageModel
    {
        private readonly IStudentData studentData;

        public Student Student { get; set; }
        [TempData]
        public string Message { get; set; }

        public DetailModel(IStudentData studentData)
        {
            this.studentData = studentData;
        }

        public IActionResult OnGet(int id)
        {
            Student = studentData.GetStudentById(id);
            if(Student == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        
    }
}
