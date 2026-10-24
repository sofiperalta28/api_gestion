using System.ComponentModel.DataAnnotations;

namespace entity_library;
public class Person
{
    private long id = 0;
    private string name = "";
    private string? dni;
    private int age;

    public long Id { get => id; set => id = value; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
    public string Name { get => name; set => name = value; }

    [StringLength(15, ErrorMessage = "El DNI no puede superar los 15 caracteres")]
    public string? Dni { get => dni; set => dni = value; }

    [Range(1, 120, ErrorMessage = "La edad debe estar entre 1 y 120 años")]
    public int Age { get => age; set => age = value; }

    public Person()
    {
    }

    public Person(long id, string name, string? dni, int age)
    {
        Id = id;
        Name = name;
        Dni = dni;
        Age = age;
    }
}