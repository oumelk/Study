using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Study.Core;
using Study.Data;
using System.Collections.Generic;

namespace Study.Pages.Students
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IStudentData studentData;

        public IEnumerable<Student> Students { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IStudentData studentData)
        {
            this.config = config;
            this.studentData = studentData;
        }

        public void OnGet()
        {
            Students = studentData.GetStudentsByName(SearchTerm);
        }


    }
}
