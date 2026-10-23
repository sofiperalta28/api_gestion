using System;
using System.Collections.Generic;
using entity_library;

namespace dao_library;

public static class MockDatabase
{
    public static List<Person> Persons { get; set; } = new List<Person>()
    {
        new Person { Id = 1, Name = "Mariana Garcia", Age = 29, Dni = "38111222" },
        new Person { Id = 2, Name = "Gonzalo Martinez", Age = 34, Dni = "35444555" },
        new Person { Id = 3, Name = "Camila Benitez", Age = 26, Dni = "40777888" }
    };

    public static List<Trainer> Trainers { get; set; } = new List<Trainer>()
    {
        new Trainer { Id = 1, Name = "Esteban Quito", Age = 42, Dni = "28999000" },
        new Trainer { Id = 2, Name = "Romina Fernandez", Age = 39, Dni = "31222333" },
        new Trainer { Id = 3, Name = "Javier Morales", Age = 45, Dni = "26444555" }
    };

    public static List<Player> Players { get; set; } = new List<Player>()
    {
        new Player { Id = 1, Name = "Mateo Fernandez", Age = 23, Dni = "43111222", Number = 5 }, 
        new Player { Id = 2, Name = "Federico Navarro", Age = 27, Dni = "39333444", Number = 11 }, 
        new Player { Id = 3, Name = "Ignacio Herrera", Age = 24, Dni = "42555666", Number = 1 } 
    };

    public static List<Team> Teams { get; set; } = new List<Team>()
    {
        new Team { Id = 1, Name = "Alem", Category = "Seniors" },
        new Team { Id = 2, Name = "San Martin", Category = "Primera A" },
        new Team { Id = 3, Name = "Huracan", Category = "Promocional" }
    };

    public static List<Student> Students { get; set; } = new List<Student>()
    {
        new Student { Id = 1, Name = "Agustina Paz", Age = 19, Dni = "48111222", File = "ST101" },
        new Student { Id = 2, Name = "Bruno Acosta", Age = 21, Dni = "45333444", File = "ST102" },
        new Student { Id = 3, Name = "Florencia Gimenez", Age = 20, Dni = "46555666", File = "ST103" }
    };

    public static List<Course> Courses { get; set; } = new List<Course>()
    {
        new Course { Id = 1, Name = "Diseno UX/UI" },
        new Course { Id = 2, Name = "Arquitectura de Software" },
        new Course { Id = 3, Name = "Inteligencia Artificial" }
    };

    public static List<Activity> Activities { get; set; } = new List<Activity>()
    {
        new Activity
        {
            Id = 1,
            Title = "Revision de Codigo",
            Description = "Hacer Pull Request review de la rama feature/login.",
            Date = new DateTime(2026, 11, 10)
        },
        new Activity
        {
            Id = 2,
            Title = "Deploy a Staging",
            Description = "Subir los ultimos cambios al entorno de pruebas.",
            Date = new DateTime(2026, 11, 12)
        },
        new Activity
        {
            Id = 3,
            Title = "Sprint Planning",
            Description = null,
            Date = new DateTime(2026, 11, 15)
        }
    };
}