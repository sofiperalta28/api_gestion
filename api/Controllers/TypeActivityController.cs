using Microsoft.AspNetCore.Mvc;
using dao_library;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeActivityController : ControllerBase
    {
        private readonly TypeActivityDao _typeActivityDao = new TypeActivityDao();

        //GET: api/typeactivity
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _typeActivityDao.GetTypeActivities();
            return Ok(result);
        }
    }
}