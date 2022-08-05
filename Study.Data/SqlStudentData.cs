using Microsoft.EntityFrameworkCore;
using Study.Core;
using System.Collections.Generic;
using System.Linq;

namespace Study.Data
{
    public class SqlStudentData : IStudentData
    {
        private readonly StudyDbContext db;

        public SqlStudentData(StudyDbContext db)
        {
            this.db = db;
        }

        public Student Add(Student newStudent)
        {
            db.Add(newStudent);
            return newStudent;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Student Delete(int id)
        {
            Student student = GetStudentById(id);
            if(student != null)
            {
                db.Remove(student);
            }
            return student;
        }

        public int GetCountStudents()
        {
            return db.Students.Count();
        }

        public Student GetStudentById(int id)
        {
            return db.Students.Find(id);
        }

        public IEnumerable<Student> GetStudentsByName(string name)
        {
            return from student in db.Students
                   where student.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                   orderby student.Age
                   select student;
        }

        public Student Update(Student updatedStudent)
        {
            var entity = db.Attach(updatedStudent);
            entity.State = EntityState.Modified;
            return updatedStudent;
        }
    }
}
