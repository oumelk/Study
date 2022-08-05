using Study.Core;
using System.Collections.Generic;
using System.Linq;

namespace Study.Data
{
    public class InMemoryStudentData : IStudentData
    {
        readonly List<Student> students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Name = "Salah",
                Age = 24,
                Nationality = Nationality.Moroccan
            },
            new Student()
            {
                Id = 2,
                Name = "Imane",
                Age = 23,
                Nationality = Nationality.Moroccan
            },
            new Student()
            {
                Id = 3,
                Name = "Oussama",
                Age = 22,
                Nationality = Nationality.French
            }
        };

        public IEnumerable<Student> GetStudentsByName(string name = null)
        {
            return from s in students
                   where string.IsNullOrEmpty(name) || s.Name.StartsWith(name)
                   orderby s.Age
                   select s;
        }

        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public Student Update(Student updatedStudent)
        {
            Student student = students.FirstOrDefault(s => s.Id == updatedStudent.Id);
            if(student != null)
            {
                student.Name = updatedStudent.Name;
                student.Age = updatedStudent.Age;
                student.Nationality = updatedStudent.Nationality;
            }
            return student;
        }

        public int Commit()
        {
            return 0;
        }

        public Student Add(Student newStudent)
        {
            students.Add(newStudent);
            newStudent.Id = students.Max(s => s.Id) + 1;
            return newStudent;
        }

        public Student Delete(int id)
        {
            Student student = students.FirstOrDefault(s => s.Id == id);
            if(null != student)
            {
                students.Remove(student);
            }
            return student;
        }

        public int GetCountStudents()
        {
            return students.Count;
        }
    }
}
