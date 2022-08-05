using Microsoft.EntityFrameworkCore;
using Study.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.Data
{
    public class StudyDbContext : DbContext
    {
        public StudyDbContext(DbContextOptions<StudyDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
