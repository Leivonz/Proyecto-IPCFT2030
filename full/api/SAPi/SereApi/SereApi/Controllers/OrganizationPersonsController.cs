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
    public class OrganizationPersonsController : ControllerBase
    {
        private readonly SereDbContext _context = new();

        // GET: api/OrganizationPersons
        [HttpGet]
        public async Task<IActionResult> GetOrganizationPeople()
        {
            Response response = new();
            try
            {
                if (_context.OrganizationPeople == null)
                {
                    response.Message = "Table 'OrganizationPerson' doesn't exist";
                    return NotFound(response);
                }
                var OrganizationPeople = await _context.OrganizationPeople.Select(x => new
                {
                    id = x.IdOrganizationPerson,
                    idorganization = x.IdOrganization,
                    idperson = x.IdOrganizationPerson
                }).ToListAsync();
                if (OrganizationPeople != null)
                {
                    if (OrganizationPeople.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = OrganizationPeople;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // PUT: api/OrganizationPersons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizationPerson(int id, OrganizationPerson organizationPerson)
        {
            Response response = new();
            try
            {
                if (_context.OrganizationPeople == null)
                {
                    response.Message = "Table 'OrganizationPerson' doesnt exist";
                    return NotFound(response);
                }
                var findOrganizationPerson = await _context.EventTypes.FindAsync(id);
                if (findOrganizationPerson == null)
                {
                    response.Message = $"Event type with Id: {id} not found";
                    return NotFound(response);
                }
                if (findOrganizationPerson != null)
                {
                    response.Success = true;
                    response.Data = findOrganizationPerson;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // POST: api/OrganizationPersons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrganizationPerson>> PostOrganizationPerson(int idperson, int idorganization)
        {
            Response response = new();
            if (_context.OrganizationPeople == null)
            {
                response.Message= "Entity set 'SereDbContext.OrganizationPeople'  is null.";
                return NotFound(response);
            }
            OrganizationPerson orgP = new();
            orgP.IdPerson = idperson;
            orgP.IdOrganization = idorganization;
            _context.OrganizationPeople.Add(orgP);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = "Succesfully saved";
            return Ok(response);
        }

        // DELETE: api/OrganizationPersons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizationPerson(int id)
        {
            Response response = new();
            if (_context.OrganizationPeople == null)
            {
                response.Message = "Table 'OrganizacionPerson' doesn't exist";
                return BadRequest(response);
            }
            var organizationPerson = await _context.OrganizationPeople.FindAsync(id);
            if (organizationPerson == null)
            {
                response.Message = $"No OrganizacionPerson with id: {id}";
                return BadRequest(response);
            }

            _context.OrganizationPeople.Remove(organizationPerson);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = $"Successfully deleted OrganizationPerson with id: {id}";
            response.Data = organizationPerson;
            return Ok(response);
        }

        private bool OrganizationPersonExists(int id)
        {
            return (_context.OrganizationPeople?.Any(e => e.IdOrganizationPerson == id)).GetValueOrDefault();
        }
    }
}
