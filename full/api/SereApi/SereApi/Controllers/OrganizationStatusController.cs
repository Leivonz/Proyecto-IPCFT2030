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
    public class OrganizationStatusController : ControllerBase
    {
        private readonly SereDbContext _context = new();


        // GET: api/OrganizationStatus
        [HttpGet]
        public async Task<IActionResult> GetOrganizationStatuses()
        {
            Response response = new();
            try
            {
                if (_context.OrganizationStatuses == null)
                {
                    response.Message = "Table 'OrganizationStatus' doesn't exist";
                    return NotFound(response);
                }
                var OrganizationStatuses = await _context.OrganizationStatuses.Select(x => new
                {
                    id = x.IdOrganizationStatus,
                    name = x.NameOrganizationStatus
                }).ToListAsync();
                if (OrganizationStatuses != null)
                {
                    if (OrganizationStatuses.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = OrganizationStatuses;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // GET: api/OrganizationStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationStatus>> GetOrganizationStatus(int id)
        {
            Response response = new();
            try
            {
                if (_context.OrganizationStatuses == null)
                {
                    response.Message = "Table 'OrganizationStatus' doesn't exist";
                    return NotFound(response);
                }
                var findOrganizationStatus = await _context.EventTypes.FindAsync(id);
                if (findOrganizationStatus == null)
                {
                    response.Message = $"Organization Status with Id: {id} not found";
                    return NotFound(response);
                }
                if (findOrganizationStatus != null)
                {
                    response.Success = true;
                    response.Data = findOrganizationStatus;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // PUT: api/OrganizationStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizationStatus(int id, OrganizationStatus organizationStatus)
        {
            if (id != organizationStatus.IdOrganizationStatus)
            {
                return BadRequest();
            }

            _context.Entry(organizationStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationStatusExists(id))
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

        // POST: api/OrganizationStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrganizationStatus>> PostOrganizationStatus(string name)
        {
            Response response = new();
            if (_context.OrganizationStatuses == null)
            {
                response.Message = "Entity set 'SereDbContext.OrganizationStatuses'  is null.";
                return NotFound(response);
            }
            OrganizationStatus orgstat = new();
            orgstat.NameOrganizationStatus = name;

            _context.OrganizationStatuses.Add(orgstat);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = "Succesfully saved";

            return Ok(response);
        }

        // DELETE: api/OrganizationStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizationStatus(int id)
        {
            Response response = new();
            if (_context.OrganizationStatuses == null)
            {
                response.Message = "Table 'OrganizationStatus' doesn't exist";
                return BadRequest(response);
            }
            var organizationStatus = await _context.OrganizationStatuses.FindAsync(id);
            if (organizationStatus == null)
            {
                response.Message = $"No OrganizationStatus with id: {id}";
                return BadRequest(response);
            }

            _context.OrganizationStatuses.Remove(organizationStatus);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = $"Successfully deleted OrganizationStatus with id: {id}";
            response.Data = organizationStatus;
            return Ok(response);
        }

        private bool OrganizationStatusExists(int id)
        {
            return (_context.OrganizationStatuses?.Any(e => e.IdOrganizationStatus == id)).GetValueOrDefault();
        }
    }
}
