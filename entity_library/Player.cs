using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace entity_library
{
    public class Player : Person
    {
        private int number;

        [Range(1, 99, ErrorMessage = "El número de camiseta debe estar entre 1 y 99")]
        public int Number { get => number; set => number = value; }

        public List<Team> TeamList { get; set; }

        public Player()
        {
            TeamList = new List<Team>();
        }

        public Player(long id, string name, string? dni, int age, int number)
            : base(id, name, dni, age)
        {
            Number = number;
            TeamList = new List<Team>();
        }
    }
}