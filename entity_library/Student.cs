using System.Collections.Generic;

namespace entity_library
{
    public class Student : Person
    {
        private string file = "";

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
