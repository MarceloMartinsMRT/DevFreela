using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //api/projects?query=netcore
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            // buscar todos/listar
            var getAllProjectsQuery = new GetAllProjectsQuery(query);

            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }

        // api/projects/599
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            //Buscar o projeto
            //return NotFound();

            var query = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);

        }

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] CreateProjectCommand command)
        {

            if (command.Title.Length > 50)
                return BadRequest();

            var id = _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { Id = id }, command);
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int id,
            [FromBody] UpdateProjectCommand command)
        {
            if (command.Description.Length > 200)
            {
                return BadRequest();
            }

            //atualizo o objeto

            _mediator.Send(command);

            return NoContent();
        }


        //api/projects/3

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            //buscar, se não existir, retorna notfound

            //remover
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // api/projects/1/start
        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();

        }

        //api/projects/1/finish
        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand(id);


            await _mediator.Send(command);

            return NoContent();
        }
    }
}
