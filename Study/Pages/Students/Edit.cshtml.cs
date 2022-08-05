using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Study.Core;
using Study.Data;
using System.Collections.Generic;

namespace Study.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IStudentData studentData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Student Student { get; set; }

        public IEnumerable<SelectListItem> Nationalities { get; set; }

        public EditModel(IStudentData studentData, IHtmlHelper htmlHelper)
        {
            this.studentData = studentData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? id)
        {
            Nationalities = htmlHelper.GetEnumSelectList<Nationality>();
            if (id.HasValue)
            {
                Student = studentData.GetStudentById(id.Value);
            }
            else
            {
                Student = new Student();
            }
            if (Student == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Nationalities = htmlHelper.GetEnumSelectList<Nationality>();
                return Page();
            }

            if(Student.Id == 0)
            {
                studentData.Add(Student);
            }
            else
            {
                studentData.Update(Student);
            }
            TempData["Message"] = "Student Saved!";
            studentData.Commit();
            return RedirectToPage("./Detail", new { id = Student.Id });
        }
    }
}
