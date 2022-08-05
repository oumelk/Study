using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Study.Core;
using Study.Data;

namespace Study.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentData studentData;

        public Student Student { get; set; }

        public DeleteModel(IStudentData studentData)
        {
            this.studentData = studentData;
        }
        public IActionResult OnGet(int id)
        {
            Student = studentData.GetStudentById(id);
            if (Student == null)
            {
                return RedirectToPage("./NotFound");

            }
            return Page();




        }

        public IActionResult OnPost(int id)
        {
            Student student = studentData.Delete(id);
            studentData.Commit();
            if (student == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{student.Name} was deleted!";
            return RedirectToPage("./List");
        }
    }
}
