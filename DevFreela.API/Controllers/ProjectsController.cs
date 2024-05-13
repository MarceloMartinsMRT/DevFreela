using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
        }

        // api/projects/599
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            //return NotFound();
            return Ok();

        }
    }
}
