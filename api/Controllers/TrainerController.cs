using Microsoft.AspNetCore.Mvc;
using entity_library;
using dao_library;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainerController : ControllerBase
    {
        private readonly TrainerDao _trainerDao = new TrainerDao();

        //GET: api/trainer
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _trainerDao.GetTrainers();
            return Ok(result);
        }

        //GET: api/trainer/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var trainers = _trainerDao.GetTrainers();
            var found = trainers.FirstOrDefault(t => t.Id == id);

            if (found == null)
            {
                return NotFound($"No se encontró el entrenador con ID {id}");
            }

            return Ok(found);
        }

        //POST: api/trainer
        [HttpPost]
        public IActionResult Create([FromBody] Trainer trainer)
        {
            if (trainer == null)
            {
                return BadRequest("Datos inválidos");
            }

            var created = _trainerDao.PostTrainer(trainer);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        //PUT: api/trainer/{id}
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Trainer trainer)
        {
            if (trainer == null)
            {
                return BadRequest("Datos inválidos");
            }

            trainer.Id = id;
            var updated = _trainerDao.PutTrainer(trainer);

            if (updated == null)
            {
                return NotFound($"No se pudo actualizar. No existe el entrenador con ID {id}");
            }

            return Ok(updated);
        }

        //DELETE: api/trainer/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var trainerToDelete = new Trainer { Id = id };
            bool deleted = _trainerDao.DeleteTrainer(trainerToDelete);

            if (!deleted)
            {
                return NotFound($"No se encontró el entrenador con ID {id} para eliminar");
            }

            return Ok(new { message = $"Entrenador con ID {id} eliminado correctamente" });
        }
    }
}