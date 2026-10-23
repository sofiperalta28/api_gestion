using System;
using System.Collections.Generic;

namespace entity_library
{
    public class Course
    {
        private string name;
        private long id;

        public string Name { get => name; set => name = value; }
        public long Id { get => id; set => id = value; }
        public List<Student> StudentList { get; set; }
        public List<Activity> ActivityList { get; set; }

        public Course()
        {
            StudentList = new List<Student>();
            ActivityList = new List<Activity>();
        }

        public Course(string name, long id)
        {
            Name = name;
            Id = id;
            StudentList = new List<Student>();
            ActivityList = new List<Activity>();
        }
    }
}