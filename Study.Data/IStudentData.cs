using Study.Core;
using System.Collections.Generic;

namespace Study.Data
{
    public interface IStudentData
    {
        IEnumerable<Student> GetStudentsByName(string name);
        Student GetStudentById(int id);
        Student Update(Student updatedStudent);
        Student Add(Student newStudent);
        Student Delete(int id);
        int Commit();
        int GetCountStudents();
    }
}
