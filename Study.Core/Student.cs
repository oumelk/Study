using System.ComponentModel.DataAnnotations;

namespace Study.Core
{

    public class Student
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, Range(1, 200)]
        public int Age { get; set; }
        public  Nationality Nationality { get; set; }
    }
}
