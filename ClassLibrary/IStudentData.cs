using Study.Core;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public interface IStudentData
    {
        IEnumerable<Student> GetAll();
    }
    public class InMemoryStudentData : IStudentData
    {
        readonly List<Student> students;

        public InMemoryStudentData()
        {
            students = new List<Student>
            {
                new Student { Id = 1, Name = "imane", Age = 22, Nationality = Nationality.Moroccan },
                new Student { Id = 2, Name = "salah", Age = 23, Nationality = Nationality.Moroccan },
                new Student { Id = 3, Name = "fadli", Age = 22, Nationality = Nationality.French }
            };
        }

        public IEnumerable<Student> GetAll()
        {
            return from s in students
                   orderby s.Age
                   select s;
        }
    }
}
