using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        //api/projects?query=netcore
        [HttpGet]
        public IActionResult Get(string query)
        {
            // buscar todos/listar
            return Ok();
        }

        // api/projects/599
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            //Buscar o projeto
            //return NotFound();
            return Ok();

        }

        [HttpPost]
        public IActionResult Post(
            [FromBody] CreateProjectModel createProject)
        {
            if (createProject.Title.Length > 50)
            {
                return BadRequest();
            }

            //cadastrar o projeto

            return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
        }

        //api/projects/2
        [HttpPut("id")]
        public IActionResult Put(int id,
            [FromBody] UpdateProjectModel updateProject)
        {
            if (updateProject.Description.Length > 200)
            {
                return BadRequest();
            }

            //atualizo o objeto

            return NoContent();
        }


        //api/projects/3
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            //buscar, se não existir, retorna notfound

            //remover


            return NoContent();
        }

    }
}
