using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace entity_library
{
    public class Student : Person
    {
        private string file = "";

        [Required(ErrorMessage = "El legajo es obligatorio")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El legajo debe tener entre 3 y 20 caracteres")]
        public string File { get => file; set => file = value; }

        public List<Course> ListCourse { get; set; }

        public Student()
        {
            ListCourse = new List<Course>();
        }

        public Student(long id, string name, string? dni, int age, string file)
            : base(id, name, dni, age)
        {
            File = file;
            ListCourse = new List<Course>();
        }
    }
}