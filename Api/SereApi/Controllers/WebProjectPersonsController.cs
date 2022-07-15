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
    public class WebProjectPersonsController : ControllerBase
    {
        private readonly SereDbContext _context = new();

        // GET: api/WebProjectPersons
        [HttpGet]
        public async Task<IActionResult> GetWebProjectPeople()
        {
            Response response = new();
            try
            {
                if (_context.WebProjectPeople == null)
                {
                    response.Message = "Table 'WebProjectPeople' doesn't exist";
                    return NotFound(response);
                }
                var webProjectPeople = await _context.WebProjectPeople.Select(x => new
                {
                    idWebProject = x.IdWebProject,
                    idWebProjectPerson = x.IdWebProjectPerson,
                    idPerson = x.IdPerson
                }).ToListAsync();
                if (webProjectPeople != null)
                {
                    if (webProjectPeople.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = webProjectPeople;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // GET: api/WebProjectPersons/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWebProjectPerson(int id)
        {
            Response response = new();
            try
            {
                if (_context.WebProjectPeople == null)
                {
                    response.Message = "Table doesnt exist";
                    return NotFound(response);
                }
                var findWebProjectPeople = await _context.WebProjectPeople.FindAsync(id);
                if (findWebProjectPeople == null)
                {
                    response.Message = $"WebProjectPeople with Id: {id} not found";
                    return NotFound(response);
                }
                if (findWebProjectPeople != null)
                {
                    response.Success = true;
                    response.Data = findWebProjectPeople;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // PUT: api/WebProjectPersons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWebProjectPerson(int id, WebProjectPerson webProjectPerson)
        {
            if (id != webProjectPerson.IdWebProjectPerson)
            {
                return BadRequest();
            }

            _context.Entry(webProjectPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebProjectPersonExists(id))
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

        // POST: api/WebProjectPersons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WebProjectPerson>> PostWebProjectPerson(int idPerson,int idWebProject)
        {
            Response response = new();
            if (_context.WebProjectPeople == null)
            {
                //return Problem("Entity set 'SereDbContext.Countries'  is null.");
                response.Message = "Table 'WebProjectPerson' doesn't exist";
                return NotFound(response);
            }
            WebProjectPerson webProjectPerson = new();
            webProjectPerson.IdWebProjectPerson = idPerson;
            webProjectPerson.IdWebProject = idWebProject;
            _context.WebProjectPeople.Add(webProjectPerson);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = "Succesfully saved";
            response.Data = webProjectPerson;
            return Ok(response);
        }

        // DELETE: api/WebProjectPersons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            Response response = new();
            if (_context.WebProjectPeople == null)
            {
                response.Message = "Table 'WebProjectPeople' doesn't exist";
                return NotFound(response);

            }
            var webProjectPeople = await _context.WebProjectPeople.FindAsync(id);
            if (webProjectPeople == null)
            {
                response.Message = $"No WebProjectPerson with id: {id}";
                return NotFound(response);
            }

            _context.WebProjectPeople.Remove(webProjectPeople);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = $"Successfully deleted WebProjectPerson with id: {id}";
            response.Data = webProjectPeople;
            return Ok(response);
        }

        private bool WebProjectPersonExists(int id)
        {
            return (_context.WebProjectPeople?.Any(e => e.IdWebProjectPerson == id)).GetValueOrDefault();
        }
    }
}
