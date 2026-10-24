using Microsoft.AspNetCore.Mvc;
using entity_library;
using dao_library;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly TeamDao _teamDao = new TeamDao();

        //GET: api/team
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _teamDao.GetTeam();
            return Ok(result);
        }

        //GET: api/team/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var teams = _teamDao.GetTeam();
            var found = teams.FirstOrDefault(t => t.Id == id);

            if (found == null)
            {
                return NotFound($"No se encontró el equipo con ID {id}");
            }

            return Ok(found);
        }

        //POST: api/team
        [HttpPost]
        public IActionResult Create([FromBody] Team team)
        {
            if (team == null)
            {
                return BadRequest("Datos inválidos");
            }

            var created = _teamDao.PostTeam(team);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        //PUT: api/team/{id}
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Team team)
        {
            if (team == null)
            {
                return BadRequest("Datos inválidos");
            }

            team.Id = id;
            var updated = _teamDao.PutTeam(team);

            if (updated == null)
            {
                return NotFound($"No se pudo actualizar. No existe el equipo con ID {id}");
            }

            return Ok(updated);
        }

        //DELETE: api/team/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var teamToDelete = new Team { Id = id };
            bool deleted = _teamDao.DeleteTeam(teamToDelete);

            if (!deleted)
            {
                return NotFound($"No se encontró el equipo con ID {id} para eliminar");
            }

            return Ok(new { message = $"Equipo con ID {id} eliminado correctamente" });
        }
    }
}