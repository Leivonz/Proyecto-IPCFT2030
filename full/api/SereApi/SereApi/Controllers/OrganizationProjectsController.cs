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
    public class OrganizationProjectsController : ControllerBase
    {
        private readonly SereDbContext _context = new();


        // GET: api/OrganizationProjects
        [HttpGet]
        public async Task<IActionResult> GetOrganizationProjects()
        {
            Response response = new();
            try
            {
                if (_context.OrganizationProjects == null)
                {
                    response.Message = "Table 'OrganizationProject' doesn't exist";
                    return NotFound(response);
                }
                var organizationProjects = await _context.OrganizationProjects.Select(x => new
                {
                    id = x.IdOrganizationProject,
                    idproject = x.IdProject,
                    idorgnaization = x.IdOrganization
                }).ToListAsync();
                if (organizationProjects != null)
                {
                    if (organizationProjects.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = organizationProjects;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // GET: api/OrganizationProjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationProject>> GetOrganizationProject(int id)
        {
            Response response = new();
            try
            {
                if (_context.OrganizationProjects == null)
                {
                    response.Message = "Table 'OrganizationProject' doesnt exist";
                    return NotFound(response);
                }
                var findOrganizationProjects = await _context.OrganizationProjects.FindAsync(id);
                if (findOrganizationProjects == null)
                {
                    response.Message = $"Organization Project with Id: {id} not found";
                    return NotFound(response);
                }
                if (findOrganizationProjects != null)
                {
                    response.Success = true;
                    response.Data = findOrganizationProjects;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // PUT: api/OrganizationProjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizationProject(int id, OrganizationProject organizationProject)
        {
            if (id != organizationProject.IdOrganizationProject)
            {
                return BadRequest();
            }

            _context.Entry(organizationProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationProjectExists(id))
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

        // POST: api/OrganizationProjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrganizationProject>> PostOrganizationProject(int idproject, int idorgnaization)
        {
            Response response = new();
            if (_context.OrganizationProjects == null)
            {
                response.Message= "Entity set 'SereDbContext.OrganizationProjects'  is null.";
                return NotFound(response);
            }
            OrganizationProject OrgPro=new();
            OrgPro.IdProject = idproject;
            OrgPro.IdOrganization = idorgnaization;


            _context.OrganizationProjects.Add(OrgPro);
            await _context.SaveChangesAsync();
            return Ok(response);
        }

        // DELETE: api/OrganizationProjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizationProject(int id)
        {
            Response response = new();
            if (_context.OrganizationProjects == null)
            {
                response.Message = "Table 'OrganizationProject' doesn't exist";
                return BadRequest(response);
            }
            var organizationProject = await _context.OrganizationProjects.FindAsync(id);
            if (organizationProject == null)
            {
                response.Message = $"No OrganizationProject with id: {id}";
                return BadRequest(response);
            }

            _context.OrganizationProjects.Remove(organizationProject);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = $"Successfully deleted OrganizationProject with id: {id}";
            response.Data = organizationProject;
            return Ok(response);
        }

        private bool OrganizationProjectExists(int id)
        {
            return (_context.OrganizationProjects?.Any(e => e.IdOrganizationProject == id)).GetValueOrDefault();
        }
    }
}
