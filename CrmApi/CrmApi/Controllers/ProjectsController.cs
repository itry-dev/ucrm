using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmApiLogic;
using CrmApiLogic.Interfaces;
using CrmApiLogic.Models.Projects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : BaseController
    {

        public ProjectsController(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper)
        {
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects(string q=null)
        {
            return await RepoWrapper.ProjectRepository.ListAsync(new CrmApiLogic.Specifications.Project.FindProject(q));
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(Guid id)
        {
            var project = await RepoWrapper.ProjectRepository.GetById(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(Guid id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await RepoWrapper.ProjectRepository.Edit(project);

            return NoContent();
        }

        // POST: api/Projects
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await RepoWrapper.ProjectRepository.Add(project);            

            return CreatedAtAction("GetProject", new { id = project.Id }, project);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(Guid id)
        {
            if (RepoWrapper.ProjectRepository.Exists(id))
            {
                return NotFound();
            }

            await RepoWrapper.ProjectRepository.Delete(id);

            return Ok();
        }
    }
}
