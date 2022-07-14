using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SereApi.Models;

namespace SereApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly SereDbContext _context = new();


        // GET: api/Projects
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            Response response = new();
            try
            {
                if (_context.Projects == null)
                {
                    response.Message = "Table 'Projects' doesn't exist";
                    return NotFound(response);
                }
                var projects = await _context.Projects.Select(x => new
                {
                    id = x.IdProject,
                    creation = x.CreationDateProject,
                    start = x.StartDateProject,
                    end = x.EndDateProject,
                    month = x.MonthsProject,
                    description = x.DescriptionProject,
                    keywords = x.KeyWordsProject,
                    area = x.IdArea,
                    projectstatus = x.IdProjectStatus,
                    objective = x.IdObjectiveObjective,
                    responsable = x.IdPersonResponsable
                }).ToListAsync();
                if (projects != null)
                {
                    if (projects.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = projects;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            Response response = new();
            try
            {
                if (_context.Projects == null)
                {
                    response.Message = "Table 'Projects' doesnt exist";
                    return NotFound(response);
                }
                var findProject = await _context.Projects.FindAsync(id);
                if (findProject == null)
                {
                    response.Message = $"Project with Id: {id} not found";
                    return NotFound(response);
                }
                if (findProject != null)
                {
                    response.Success = true;
                    response.Data = findProject;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.IdProject)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(DateTime CreationDateProject, DateTime StartDateProject, DateTime EndDateProject, int MonthsProject,
                                                            string DescriptionProject, string KeyWordsProject, string ObjectivesProject, int IdArea, int IdProjectStatus,
                                                            int IdObjectiveObjective, int IdPersonResponsable) 
        {
            Response response = new();
            if (_context.Projects == null)
            {
                response.Message= "Entity set 'SereDbContext.Projects'  is null.";
                return NotFound(response);
            }
            Project project = new();
            project.CreationDateProject = CreationDateProject;
            project.StartDateProject = StartDateProject;
            project.EndDateProject = EndDateProject;
            project.MonthsProject = MonthsProject;
            project.DescriptionProject = DescriptionProject;
            project.KeyWordsProject = KeyWordsProject;
            project.ObjectivesProject = ObjectivesProject;
            project.IdArea = IdArea;
            project.IdProjectStatus = IdProjectStatus;
            project.IdObjectiveObjective = IdObjectiveObjective;
            project.IdPersonResponsable = IdPersonResponsable;
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = "Succesfully saved";       
            return Ok(response);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            Response response = new();
            if (_context.Projects == null)
            {
                response.Message = "Table 'Project' doesn't exist";
                return BadRequest(response);
            }
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                response.Message = $"No Project with id: {id}";
                return BadRequest(response);
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = $"Successfully deleted Project with id: {id}";
            response.Data = project;
            return Ok(response);
        }

        private bool ProjectExists(int id)
        {
            return (_context.Projects?.Any(e => e.IdProject == id)).GetValueOrDefault();
        }
    }
}
