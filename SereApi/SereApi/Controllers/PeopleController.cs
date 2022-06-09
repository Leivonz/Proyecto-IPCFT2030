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
    public class PeopleController : ControllerBase
    {
        private readonly SereDbContext _context = new();

        // GET: api/People
        [HttpGet]
        public async Task<IActionResult> GetPersonas()
        {
            Response response = new();
            try
            {
                if (_context.People == null)
                {
                    response.Message = "Table 'Person' doesn't exist";
                    return NotFound(response);
                }
                var people = await _context.People.Select(x => new
                {
                    id = x.IdPerson,
                    name = x.NamePerson,
                    surname = x.SurnamePerson,
                    email = x.EmailPerson,
                    phone = x.PhonePerson
                }).ToListAsync();
                if (people != null)
                {
                    if (people.Count == 0)
                        response.Message = "No data";
                    response.Success = true;
                    response.Data = people;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }

        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            Response response = new();
            try
            {
                if (_context.People == null)
                {
                    response.Message = "Table Person doesn't exist";
                    return NotFound(response);
                }
                var findPerson = await _context.People.FindAsync(id);
                if (findPerson == null)
                {
                    response.Message = $"Person with Id: {id} not found";
                    return NotFound(response);
                }
                if (findPerson != null)
                {
                    response.Success = true;
                    response.Data = findPerson;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.IdPerson)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            if (_context.People == null)
            {
                return Problem("Entity set 'SereDbContext.People'  is null.");
            }
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.IdPerson }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            if (_context.People == null)
            {
                return NotFound();
            }
            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return (_context.People?.Any(e => e.IdPerson == id)).GetValueOrDefault();
        }
    }
}
