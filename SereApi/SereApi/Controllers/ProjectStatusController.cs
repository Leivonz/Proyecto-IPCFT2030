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
    public class ProjectStatusController : ControllerBase
    {
        private readonly SereDbContext _context = new();


        // GET: api/ProjectStatus
        [HttpGet]
        public async Task<IActionResult> GetProjectStatuses()
        {
            Response response = new();
            try
            {
                if (_context.ProjectStatuses == null)
                {
                    response.Message = "Table 'ProjectStatuses' doesn't exist";
                    return NotFound(response);
                }
                var ProjectStatuses = await _context.ProjectStatuses.Select(x => new
                {
                    id = x.IdProjectStatus,
                    name = x.NameProjectStatus
                }).ToListAsync();
                if (ProjectStatuses != null)
                {
                    if (ProjectStatuses.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = ProjectStatuses;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // GET: api/ProjectStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectStatus>> GetProjectStatus(int id)
        {
            Response response = new();
            try
            {
                if (_context.ProjectStatuses == null)
                {
                    response.Message = "Table 'ProjectStatuses' doesn't exist";
                    return NotFound(response);
                }
                var findProjectStatus = await _context.ProjectStatuses.FindAsync(id);
                if (findProjectStatus == null)
                {
                    response.Message = $"Project status with Id: {id} not found";
                    return NotFound(response);
                }
                if (findProjectStatus != null)
                {
                    response.Success = true;
                    response.Data = findProjectStatus;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // PUT: api/ProjectStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectStatus(int id, ProjectStatus projectStatus)
        {
            if (id != projectStatus.IdProjectStatus)
            {
                return BadRequest();
            }

            _context.Entry(projectStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectStatusExists(id))
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

        // POST: api/ProjectStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectStatus>> PostProjectStatus(ProjectStatus projectStatus)
        {
            if (_context.ProjectStatuses == null)
            {
                return Problem("Entity set 'SereDbContext.ProjectStatuses'  is null.");
            }
            _context.ProjectStatuses.Add(projectStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectStatus", new { id = projectStatus.IdProjectStatus }, projectStatus);
        }

        // DELETE: api/ProjectStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectStatus(int id)
        {
            Response response = new();
            if (_context.ProjectStatuses == null)
            {
                response.Message = "Table 'Project Status' doesn't exist";
                return BadRequest(response);
            }
            var projectStatus = await _context.ProjectStatuses.FindAsync(id);
            if (projectStatus == null)
            {
                response.Message = $"No Project Status with id: {id}";
                return BadRequest(response);
            }

            _context.ProjectStatuses.Remove(projectStatus);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = $"Successfully deleted ProjectStatus with id: {id}";
            response.Data = projectStatus;
            return Ok(response);
        }

        private bool ProjectStatusExists(int id)
        {
            return (_context.ProjectStatuses?.Any(e => e.IdProjectStatus == id)).GetValueOrDefault();
        }
    }
}
