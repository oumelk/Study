using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Study.Core;
using Study.Data;
using System.Collections.Generic;

namespace Study.Pages.Students
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IStudentData studentData;
        private readonly ILogger<ListModel> logger;

        public IEnumerable<Student> Students { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IStudentData studentData, ILogger<ListModel> logger)
        {
            this.config = config;
            this.studentData = studentData;
            this.logger = logger;
        }

        public void OnGet()
        {
            logger.LogInformation("Executing ListModel");
            Students = studentData.GetStudentsByName(SearchTerm);
        }


    }
}
