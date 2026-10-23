using System.Collections.Generic;

namespace entity_library
{
    public class Team
    {
        private string name = "";
        private string category = "";
        private long id;
        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public List<Player> TeamList { get; set; }
        public long Id { get => id; set => id = value; }

        public Team()
        {
            TeamList = new List<Player>();
        }

        public Team(string name, string category, long id)
        {
            Name = name;
            Category = category;
            Id = id;
            TeamList = new List<Player>();
        }
    }
}
