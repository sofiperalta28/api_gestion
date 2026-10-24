using entity_library;
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace entity_library
{
    public class Activity
    {
        private string title;
        private string? description;
        private DateTime date;
        private long id;

        [Required(ErrorMessage = "El título de la actividad es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El título debe tener entre 2 y 100 caracteres")]
        public string Title { get => title; set => title = value; }

        [StringLength(250, ErrorMessage = "La descripción no puede superar los 250 caracteres")]
        public string? Description { get => description; set => description = value; }

        public DateTime Date { get => date; set => date = value; }

        public List<TypeActivity> TypeActivity { get; set; }

        public long Id { get => id; set => id = value; }

        public Activity()
        {
            TypeActivity = new List<TypeActivity>();
        }

        public Activity(string title, string? description, DateTime date, long id)
        {
            Title = title;
            Description = description;
            Date = date;
            Id = id;
            TypeActivity = new List<TypeActivity>();
        }
    }
}