using Microsoft.AspNetCore.Mvc;
using entity_library;
using dao_library;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerDao _playerDao = new PlayerDao();

        //GET: api/player
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _playerDao.GetPlayer();
            return Ok(result);
        }

        //GET: api/player/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var players = _playerDao.GetPlayer();
            var found = players.FirstOrDefault(p => p.Id == id);

            if (found == null)
            {
                return NotFound($"No se encontró el jugador con ID {id}");
            }

            return Ok(found);
        }

        //POST: api/player
        [HttpPost]
        public IActionResult Create([FromBody] Player player)
        {
            if (player == null)
            {
                return BadRequest("Datos inválidos");
            }

            var created = _playerDao.PostPlayer(player);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        //PUT: api/player/{id}
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Player player)
        {
            if (player == null)
            {
                return BadRequest("Datos inválidos");
            }

            player.Id = id;
            var updated = _playerDao.PutPlayer(player);

            if (updated == null)
            {
                return NotFound($"No se pudo actualizar. No existe el jugador con ID {id}");
            }

            return Ok(updated);
        }

        //DELETE: api/player/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var playerToDelete = new Player { Id = id };
            bool deleted = _playerDao.DeletePlayer(playerToDelete);

            if (!deleted)
            {
                return NotFound($"No se encontró el jugador con ID {id} para eliminar");
            }

            return Ok(new { message = $"Jugador con ID {id} eliminado correctamente" });
        }
    }
}