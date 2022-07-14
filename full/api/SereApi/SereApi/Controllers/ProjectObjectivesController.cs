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
    public class ProjectObjectivesController : ControllerBase
    {
        private readonly SereDbContext _context = new();


        // GET: api/ProjectObjectives
        [HttpGet]
        public async Task<IActionResult> GetProjectObjectives()
        {
            Response response = new();
            try
            {
                if (_context.ProjectObjectives == null)
                {
                    response.Message = "Table 'ProjectObjective' doesn't exist";
                    return NotFound(response);
                }
                var projectObjectives = await _context.ProjectObjectives.Select(x => new
                {
                    id = x.IdProjectObjective,
                    idproject = x.IdProject,
                    idobjective = x.IdObjective
                }).ToListAsync();
                if (projectObjectives != null)
                {
                    if (projectObjectives.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = projectObjectives;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // GET: api/ProjectObjectives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectObjective>> GetProjectObjective(int id)
        {
            Response response = new();
            try
            {
                if (_context.ProjectObjectives == null)
                {
                    response.Message = "Table 'ProjectObjective' doesnt exist";
                    return NotFound(response);
                }
                var findProjectObjective = await _context.ProjectObjectives.FindAsync(id);
                if (findProjectObjective == null)
                {
                    response.Message = $"Project objective with Id: {id} not found";
                    return NotFound(response);
                }
                if (findProjectObjective != null)
                {
                    response.Success = true;
                    response.Data = findProjectObjective;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }
        // PUT: api/ProjectObjectives/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectObjective(int id, ProjectObjective projectObjective)
        {
            if (id != projectObjective.IdProjectObjective)
            {
                return BadRequest();
            }

            _context.Entry(projectObjective).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectObjectiveExists(id))
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

        // POST: api/ProjectObjectives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectObjective>> PostProjectObjective(int IdProject, int IdObjective)
        {
            Response response = new();
            if (_context.ProjectObjectives == null)
            {
                response.Message="Entity set 'SereDbContext.ProjectObjectives'  is null.";
                return NotFound(response);
            }
            ProjectObjective projectobjective = new();
            projectobjective.IdProject = IdProject;
            projectobjective.IdObjective = IdObjective;
            _context.ProjectObjectives.Add(projectobjective);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = "Succesfully saved";

            return Ok(response);
        }

        // DELETE: api/ProjectObjectives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectObjective(int id)
        {
            Response response = new();
            if (_context.ProjectObjectives == null)
            {
                response.Message = "Table 'ProjectObjective' doesn't exist";
                return BadRequest(response);
            }
            var projectObjective = await _context.ProjectObjectives.FindAsync(id);
            if (projectObjective == null)
            {
                response.Message = $"No ProjectObjective with id: {id}";
                return BadRequest(response);
            }

            _context.ProjectObjectives.Remove(projectObjective);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = $"Successfully deleted ProjectObjective with id: {id}";
            response.Data = projectObjective;
            return Ok(response);
        }

        private bool ProjectObjectiveExists(int id)
        {
            return (_context.ProjectObjectives?.Any(e => e.IdProjectObjective == id)).GetValueOrDefault();
        }
    }
}
