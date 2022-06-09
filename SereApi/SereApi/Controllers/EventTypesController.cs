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
    public class EventTypesController : ControllerBase
    {
        private readonly SereDbContext _context = new();

        // GET: api/EventTypes
        [HttpGet]
        public async Task<IActionResult> GetEventTypes()
        {
            Response response = new();
            try
            {
                if (_context.EventTypes == null)
                {
                    response.Message = "Table 'EventTypes' doesn't exist";
                    return NotFound(response);
                }
                var eventTypes = await _context.EventTypes.Select(x => new
                {
                    id = x.IdEvent,
                    name = x.NameEventType
                }).ToListAsync();
                if (eventTypes != null)
                {
                    if (eventTypes.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = eventTypes;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // GET: api/EventTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventType(int id)
        {
            Response response = new();
            try
            {
                if (_context.EventTypes == null)
                {
                    response.Message = "Table doesnt exist";
                    return NotFound(response);
                }
                var findEventType = await _context.EventTypes.FindAsync(id);
                if (findEventType == null)
                {
                    response.Message = $"Event type with Id: {id} not found";
                    return NotFound(response);
                }
                if (findEventType != null)
                {
                    response.Success = true;
                    response.Data = findEventType;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // PUT: api/EventTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventType(int id, EventType eventType)
        {
            if (id != eventType.IdEvent)
            {
                return BadRequest();
            }

            _context.Entry(eventType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTypeExists(id))
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

        // POST: api/EventTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventType>> PostEventType(EventType eventType)
        {
          if (_context.EventTypes == null)
          {
              return Problem("Entity set 'SereDbContext.EventTypes'  is null.");
          }
            _context.EventTypes.Add(eventType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventType", new { id = eventType.IdEvent }, eventType);
        }

        // DELETE: api/EventTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventType(int id)
        {
            if (_context.EventTypes == null)
            {
                return NotFound();
            }
            var eventType = await _context.EventTypes.FindAsync(id);
            if (eventType == null)
            {
                return NotFound();
            }

            _context.EventTypes.Remove(eventType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventTypeExists(int id)
        {
            return (_context.EventTypes?.Any(e => e.IdEvent == id)).GetValueOrDefault();
        }
    }
}
