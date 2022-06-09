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
    public class OrganizationTypesController : ControllerBase
    {
        private readonly SereDbContext _context = new();


        // GET: api/OrganizationTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizationType>>> GetOrganizationTypes()
        {
            Response response = new();
            try
            {
                if (_context.OrganizationTypes == null)
                {
                    response.Message = "Table 'OrganizationType' doesn't exist";
                    return NotFound(response);
                }
                var OrganizationTypes = await _context.OrganizationTypes.Select(x => new
                {
                    id = x.IdOrganizationType,
                    name = x.NameOrganizationType
                }).ToListAsync();
                if (OrganizationTypes != null)
                {
                    if (OrganizationTypes.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = OrganizationTypes;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // GET: api/OrganizationTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationType>> GetOrganizationType(int id)
        {
            Response response = new();
            try
            {
                if (_context.OrganizationTypes == null)
                {
                    response.Message = "Table 'OrganizationType' doesn't exist";
                    return NotFound(response);
                }
                var findOrganizationType = await _context.OrganizationTypes.FindAsync(id);
                if (findOrganizationType == null)
                {
                    response.Message = $"Organization Type with Id: {id} not found";
                    return NotFound(response);
                }
                if (findOrganizationType != null)
                {
                    response.Success = true;
                    response.Data = findOrganizationType;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // PUT: api/OrganizationTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizationType(int id, OrganizationType organizationType)
        {
            if (id != organizationType.IdOrganizationType)
            {
                return BadRequest();
            }

            _context.Entry(organizationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationTypeExists(id))
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

        // POST: api/OrganizationTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrganizationType>> PostOrganizationType(OrganizationType organizationType)
        {
          if (_context.OrganizationTypes == null)
          {
              return Problem("Entity set 'SereDbContext.OrganizationTypes'  is null.");
          }
            _context.OrganizationTypes.Add(organizationType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganizationType", new { id = organizationType.IdOrganizationType }, organizationType);
        }

        // DELETE: api/OrganizationTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizationType(int id)
        {
            if (_context.OrganizationTypes == null)
            {
                return NotFound();
            }
            var organizationType = await _context.OrganizationTypes.FindAsync(id);
            if (organizationType == null)
            {
                return NotFound();
            }

            _context.OrganizationTypes.Remove(organizationType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganizationTypeExists(int id)
        {
            return (_context.OrganizationTypes?.Any(e => e.IdOrganizationType == id)).GetValueOrDefault();
        }
    }
}
