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
    public class OrganizationObjectivesController : ControllerBase
    {
        private readonly SereDbContext _context = new();

        // GET: api/OrganizationObjectives
        [HttpGet]
        public async Task<IActionResult> GetOrganizationObjectives()
        {
            Response response = new();
            try
            {
                if (_context.OrganizationObjectives == null)
                {
                    response.Message = "Table 'OrganizationObjectives' doesn't exist";
                    return NotFound(response);
                }
                var OrganizationObjectives = await _context.OrganizationObjectives.Select(x => new
                {
                    id = x.IdOrganizationObjective,
                    idorganizatio = x.IdOrganization,
                    idobjective = x.IdObjective
                }).ToListAsync();
                if (OrganizationObjectives != null)
                {
                    if (OrganizationObjectives.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = OrganizationObjectives;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // GET: api/OrganizationObjectives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationObjective>> GetOrganizationObjective(int id)
        {
            Response response = new();
            try
            {
                if (_context.OrganizationObjectives == null)
                {
                    response.Message = "Table 'OrganizationObjectives' doesn't exist";
                    return NotFound(response);
                }
                var findOrganizationObjectives = await _context.OrganizationObjectives.FindAsync(id);
                if (findOrganizationObjectives == null)
                {
                    response.Message = $"Organization Objective with Id: {id} not found";
                    return NotFound(response);
                }
                if (findOrganizationObjectives != null)
                {
                    response.Success = true;
                    response.Data = findOrganizationObjectives;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // PUT: api/OrganizationObjectives/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizationObjective(int id, OrganizationObjective organizationObjective)
        {
            if (id != organizationObjective.IdOrganizationObjective)
            {
                return BadRequest();
            }

            _context.Entry(organizationObjective).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationObjectiveExists(id))
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

        // POST: api/OrganizationObjectives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrganizationObjective>> PostOrganizationObjective(int idorganization, int idobjective)
        {
            Response response = new();
            if (_context.OrganizationObjectives == null)
            {
                response.Message= "Entity set 'SereDbContext.OrganizationObjectives'  is null.";
                return NotFound(response);
            }
            OrganizationObjective OrgObj= new();
            OrgObj.IdOrganization = idorganization;
            OrgObj.IdObjective = idobjective;

            _context.OrganizationObjectives.Add(OrgObj);
            await _context.SaveChangesAsync();

            return Ok(response);
        }

        // DELETE: api/OrganizationObjectives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizationObjective(int id)
        {
            Response response = new();
            if (_context.OrganizationObjectives == null)
            {
                response.Message = "Table 'OrganizationObjective' doesn't exist";
                return BadRequest(response);
            }
            var organizationObjective = await _context.OrganizationObjectives.FindAsync(id);
            if (organizationObjective == null)
            {
                response.Message = $"No organization objective with id: {id}";
                return BadRequest(response);
            }

            _context.OrganizationObjectives.Remove(organizationObjective);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = $"Successfully deleted organization objective with id: {id}";
            response.Data = organizationObjective;
            return Ok(response);

        }

        private bool OrganizationObjectiveExists(int id)
        {
            return (_context.OrganizationObjectives?.Any(e => e.IdOrganizationObjective == id)).GetValueOrDefault();
        }
    }
}
