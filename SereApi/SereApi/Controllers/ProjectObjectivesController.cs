﻿using System;
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
        public async Task<ActionResult<ProjectObjective>> PostProjectObjective(ProjectObjective projectObjective)
        {
          if (_context.ProjectObjectives == null)
          {
              return Problem("Entity set 'SereDbContext.ProjectObjectives'  is null.");
          }
            _context.ProjectObjectives.Add(projectObjective);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectObjective", new { id = projectObjective.IdProjectObjective }, projectObjective);
        }

        // DELETE: api/ProjectObjectives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectObjective(int id)
        {
            if (_context.ProjectObjectives == null)
            {
                return NotFound();
            }
            var projectObjective = await _context.ProjectObjectives.FindAsync(id);
            if (projectObjective == null)
            {
                return NotFound();
            }

            _context.ProjectObjectives.Remove(projectObjective);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectObjectiveExists(int id)
        {
            return (_context.ProjectObjectives?.Any(e => e.IdProjectObjective == id)).GetValueOrDefault();
        }
    }
}
