using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Study.Core;
using Study.Data;

namespace Study.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly Study.Data.StudyDbContext _context;

        public IndexModel(Study.Data.StudyDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Students.ToListAsync();
        }
    }
}
