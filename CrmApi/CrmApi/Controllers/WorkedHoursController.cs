using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmApiLogic;
using CrmApiLogic.ApiModels;
using CrmApiLogic.Interfaces;
using CrmApiLogic.Models.Projects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkedHoursController : BaseController
    {

        public WorkedHoursController(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkedHour>>> GetWorkedHours(int year, int month=0, int day=0)
        {
            return await RepoWrapper.WorkedHoursRepository.ListAsync(new CrmApiLogic.Specifications.Project.GetWorkedHoursList(year, month, day, null));
        }

        [HttpPost]
        [Route("WorkedHoursOnProjects")]
        public async Task<ActionResult<IEnumerable<WorkedHour>>> GetProjectWorkedHours(List<Guid> ids, int year, int month = 0, int day = 0)
        {
            return await RepoWrapper.WorkedHoursRepository.ListAsync(new CrmApiLogic.Specifications.Project.GetWorkedHoursList(year, month, day, ids));
        }

        // GET: api/WorkedHours/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<WorkedHour>> GetWorkedHours(Guid id)
        {
            var workedHour = await RepoWrapper.WorkedHoursRepository.ListAsync(new CrmApiLogic.Specifications.Project.GetWorkedHours(id));

            if (workedHour == null)
            {
                return NotFound();
            }

            return workedHour.FirstOrDefault();
        }

        [HttpGet]
        [Route("Report")]
        public async Task<ActionResult<List<Report>>> getReport(int year, int? month, Guid? projectId)
        {
            return await RepoWrapper.WorkedHoursRepository.GetReport(year, month, projectId);
        }

        [HttpGet]
        [Route("Export")]
        public async Task<ActionResult<List<WorkedHour>>> ExportDetails(Guid projectId, int year, int month)
        {
            var project = await RepoWrapper.ProjectRepository.GetById(projectId);
            if (project == null)
            {
                return BadRequest(new ClientErrorData { Title = "Project not found" });
            }

            var ms = await RepoWrapper.WorkedHoursRepository.CreateCsvFile(projectId, year, month);
            var result = new FileContentResult(ms.ToArray(), "application/octet-stream");

            if (project.Customer != null && !string.IsNullOrWhiteSpace(project.Customer.CompanyName))
            {
                result.FileDownloadName = project.Customer.CompanyName
                                            .Replace(" ","")
                                            + ".csv";

            }
            else
            {
                result.FileDownloadName = project.Id + ".csv";
            }


            return result;
        }

        // PUT: api/WorkedHours/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkedHour(Guid id, WorkedHour workedHour)
        {
            if (id != workedHour.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await RepoWrapper.WorkedHoursRepository.Edit(workedHour);

            return NoContent();
        }

        // POST: api/WorkedHours
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<WorkedHour>> PostWorkedHour(WorkedHour workedHour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await RepoWrapper.WorkedHoursRepository.Add(workedHour);

            return CreatedAtAction("GetWorkedHours", new { id = workedHour.Id }, workedHour);
        }

        // DELETE: api/WorkedHours/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkedHour(Guid id)
        {
            if (!RepoWrapper.WorkedHoursRepository.Exists(id))
            {
                return NotFound();
            }

            await RepoWrapper.WorkedHoursRepository.Delete(id);

            return Ok();
        }

    }
}
