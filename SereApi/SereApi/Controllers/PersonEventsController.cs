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
    public class PersonEventsController : ControllerBase
    {
        private readonly SereDbContext _context = new();


        // GET: api/PersonEvents
        [HttpGet]
        public async Task<IActionResult> GetPersonEvents()
        {
            Response response = new();
            try
            {
                if (_context.PersonEvents == null)
                {
                    response.Message = "Table 'PersonEvents' doesn't exist";
                    return NotFound(response);
                }
                var PersonEvents = await _context.PersonEvents.Select(x => new
                {
                    id = x.IdPersonEvent,
                    idPerson=x.IdPerson,
                    idEvent = x.IdEvent
                    
                }).ToListAsync();
                if (PersonEvents != null)
                {
                    if (PersonEvents.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = PersonEvents;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // GET: api/PersonEvents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonEvent(int id)
        {
            Response response = new();
            try
            {
                if (_context.PersonEvents == null)
                {
                    response.Message = "Table 'PersonEvents' doesnt exist";
                    return NotFound(response);
                }
                var findPersonEvents = await _context.PersonEvents.FindAsync(id);
                if (findPersonEvents == null)
                {
                    response.Message = $"PersonEvents with Id: {id} not found";
                    return NotFound(response);
                }
                if (findPersonEvents != null)
                {
                    response.Success = true;
                    response.Data = findPersonEvents;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // PUT: api/PersonEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonEvent(int id, PersonEvent personEvent)
        {
            if (id != personEvent.IdPersonEvent)
            {
                return BadRequest();
            }

            _context.Entry(personEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonEventExists(id))
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

        // POST: api/PersonEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonEvent>> PostPersonEvent(PersonEvent personEvent)
        {
          if (_context.PersonEvents == null)
          {
              return Problem("Entity set 'SereDbContext.PersonEvents'  is null.");
          }
            _context.PersonEvents.Add(personEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonEvent", new { id = personEvent.IdPersonEvent }, personEvent);
        }

        // DELETE: api/PersonEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonEvent(int id)
        {
            if (_context.PersonEvents == null)
            {
                return NotFound();
            }
            var personEvent = await _context.PersonEvents.FindAsync(id);
            if (personEvent == null)
            {
                return NotFound();
            }

            _context.PersonEvents.Remove(personEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonEventExists(int id)
        {
            return (_context.PersonEvents?.Any(e => e.IdPersonEvent == id)).GetValueOrDefault();
        }
    }
}
