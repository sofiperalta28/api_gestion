namespace entity_library;

public class Person
{
    private long id=0;
    private string name = "";
    private string? dni;
    private int age;

    public long Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public string? Dni { get => dni; set => dni = value; }
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
