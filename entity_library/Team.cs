using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace entity_library
{
    public class Team
    {
        private string name = "";
        private string category = "";
        private long id;

        [Required(ErrorMessage = "El nombre del equipo es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Name { get => name; set => name = value; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        [StringLength(50, ErrorMessage = "La categoría no puede superar los 50 caracteres")]
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