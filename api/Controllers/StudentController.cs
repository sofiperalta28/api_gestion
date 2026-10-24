using Microsoft.AspNetCore.Mvc;
using entity_library;
using dao_library;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentDao _studentDao = new StudentDao();

        //GET: api/student
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _studentDao.GetStudent();
            return Ok(result);
        }

        //GET: api/student/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var students = _studentDao.GetStudent();
            var found = students.FirstOrDefault(s => s.Id == id);

            if (found == null)
            {
                return NotFound($"No se encontró el estudiante con ID {id}");
            }

            return Ok(found);
        }

        //POST: api/student
        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Datos inválidos");
            }

            var created = _studentDao.PostStudent(student);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        //PUT: api/student/{id}
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Datos inválidos");
            }

            student.Id = id;
            var updated = _studentDao.PutStudent(student);

            if (updated == null)
            {
                return NotFound($"No se pudo actualizar. No existe el estudiante con ID {id}");
            }

            return Ok(updated);
        }

        //DELETE: api/student/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var studentToDelete = new Student { Id = id };
            bool deleted = _studentDao.Deletestudent(studentToDelete);

            if (!deleted)
            {
                return NotFound($"No se encontró el estudiante con ID {id} para eliminar");
            }

            return Ok(new { message = $"Estudiante con ID {id} eliminado correctamente" });
        }
    }
}