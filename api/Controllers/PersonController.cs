using Microsoft.AspNetCore.Mvc;
using entity_library;
using dao_library;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        //instancia de la capa dao para acceder a los datos de las personas
        private readonly PersonDao _personDao = new PersonDao();

        // 1. GET: api/person
        //devuelve la lista completa de personas
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _personDao.GetPerson();
            return Ok(result); //200 OK
        }

        // 2. GET: api/person/{id}
        //dvuelve una persona específica según su id
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var person = _personDao.GetPerson();
            var found = person.FirstOrDefault(p => p.Id == id);

            if (found == null)
            {
                return NotFound($"No se encontró la persona con ID {id}"); //404 Not Found
            }

            return Ok(found); //200 OK
        }

        // 3. POST: api/person
        //recibe un JSON en el cuerpo del mensaje y crea una nueva persona
        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest("Los datos enviados no son válidos"); //400 Bad Request
            }

            var createdPerson = _personDao.PostPerson(person);
            return CreatedAtAction(nameof(GetById), new { id = createdPerson.Id }, createdPerson); //201 Created
        }

        // 4. PUT: api/person/{id}
        // actualiza los datos de una persona existente
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest("Datos inválidos");
            }

            person.Id = id; 
            var updated = _personDao.PutPerson(person);

            if (updated == null)
            {
                return NotFound($"No se pudo actualizar. No existe persona con ID {id}"); //404 Not Found
            }

            return Ok(updated); //200 OK
        }

        // 5. DELETE: api/person/{id}
        //elimina una persona por su Id
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var personToDelete = new Person { Id = id };
            bool deleted = _personDao.DeletePerson(personToDelete);

            if (!deleted)
            {
                return NotFound($"No se encontró la persona con ID {id} para eliminar"); //404 Not Found
            }

            return Ok(new { message = $"Persona con ID {id} eliminada correctamente" }); // 200 OK
        }
    }
}