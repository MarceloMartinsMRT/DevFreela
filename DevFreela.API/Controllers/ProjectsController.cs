﻿using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        //api/projects?query=netcore
        [HttpGet]
        public IActionResult Get(string query)
        {
            // buscar todos/listar
            var projects = _projectService.GetAll(query);
            return Ok(projects);
        }

        // api/projects/599
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            //Buscar o projeto
            //return NotFound();

            var project = _projectService.GetById(id);

            if(project == null) 
            {
                return NotFound();
            }

            return Ok(project);

        }

        [HttpPost]
        public IActionResult Post(
            [FromBody] NewProjectInputModel inputModel)
        {
            if (inputModel.Title.Length > 50)
            {
                return BadRequest();
            }

            var id = _projectService.Create(inputModel);

            //cadastrar o projeto

            return CreatedAtAction(nameof(GetById), new { Id = id }, inputModel);
        }

        //api/projects/2
        [HttpPut("id")]
        public IActionResult Put(int id,
            [FromBody] UpdateProjectInputModel inputModel)
        {
            if (inputModel.Description.Length > 200)
            {
                return BadRequest();
            }

            //atualizo o objeto

            _projectService.Update(inputModel);

            return NoContent();
        }


        //api/projects/3
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            //buscar, se não existir, retorna notfound

            //remover

            _projectService.Delete(id);

            return NoContent();
        }

        // api/projects/1/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment([FromBody] CreateCommentInputModel inputModel)
        {
            _projectService.CreateComment(inputModel);

            return NoContent();
        }

        // api/projects/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);

            return NoContent();

        }

        //api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);

            return NoContent();
        }
    }
}
