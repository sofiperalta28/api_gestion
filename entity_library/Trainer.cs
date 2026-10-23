using System.Collections.Generic;

namespace entity_library
{
    public class Trainer : Person
    {
        public Trainer()
        {
        }
        public Trainer(long id, string name, string? dni, int age)
            : base(id, name, dni, age)
        {
        }
    }
}