using Microsoft.AspNetCore.Mvc;
using Study.Data;

namespace Study.Pages.ViewComponents
{
    public class StudentViewComponent : ViewComponent
    {
        private readonly IStudentData studentData;

        public StudentViewComponent(IStudentData studentData )
        {
            this.studentData = studentData;
        }

        public IViewComponentResult Invoke()
        {
            int count = studentData.GetCountStudents();
            return View(count);
        }
    }
}
