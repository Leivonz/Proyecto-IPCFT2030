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
    public class OrganizationsController : ControllerBase
    {
        private readonly SereDbContext _context = new();


        // GET: api/Organizations
        [HttpGet]
        public async Task<IActionResult> GetOrganizations()
        {
            Response response = new();
            try
            {
                if (_context.Organizations == null)
                {
                    response.Message = "Table 'Organizations' doesn't exist";
                    return NotFound(response);
                }
                var Organizations = await _context.Organizations.Select(x => new
                {
                    id = x.IdOrganization,
                    name = x.NameOrganization,
                    description = x.DescriptionOrganization,
                    email = x.EmailOrganization,
                    country = x.Country,
                    phone = x.Phone,
                    organizationtype = x.IdOrganizationType,
                    organizationstatus = x.IdOrganizationStatus

                }).ToListAsync();
                if (Organizations != null)
                {
                    if (Organizations.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = Organizations;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // GET: api/Organizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> GetOrganization(int id)
        {
            Response response = new();
            try
            {
                if (_context.Organizations == null)
                {
                    response.Message = "Table 'Organizations' doesn't exist";
                    return NotFound(response);
                }
                var findOrganization = await _context.EventTypes.FindAsync(id);
                if (findOrganization == null)
                {
                    response.Message = $"Event type with Id: {id} not found";
                    return NotFound(response);
                }
                if (findOrganization != null)
                {
                    response.Success = true;
                    response.Data = findOrganization;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // PUT: api/Organizations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganization(int id, Organization organization)
        {
            if (id != organization.IdOrganization)
            {
                return BadRequest();
            }

            _context.Entry(organization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationExists(id))
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

        // POST: api/Organizations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Organization>> PostOrganization(Organization organization)
        {
          if (_context.Organizations == null)
          {
              return Problem("Entity set 'SereDbContext.Organizations'  is null.");
          }
            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganization", new { id = organization.IdOrganization }, organization);
        }

        // DELETE: api/Organizations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization(int id)
        {
            if (_context.Organizations == null)
            {
                return NotFound();
            }
            var organization = await _context.Organizations.FindAsync(id);
            if (organization == null)
            {
                return NotFound();
            }

            _context.Organizations.Remove(organization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganizationExists(int id)
        {
            return (_context.Organizations?.Any(e => e.IdOrganization == id)).GetValueOrDefault();
        }
    }
}
