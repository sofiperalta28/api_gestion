using System.Collections.Generic;

namespace entity_library
{
    public class Player : Person
    {
        private int number;

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