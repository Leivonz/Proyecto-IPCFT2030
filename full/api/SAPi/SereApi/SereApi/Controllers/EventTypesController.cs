﻿using System;
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
        public async Task<ActionResult<EventType>> PostEventType(String tipoevento)
        {
            Response response = new();
            if (_context.EventTypes == null)
            {
                response.Message="Entity set 'SereDbContext.EventTypes'  is null.";
                return NotFound(response);
            }
            EventType ev = new();
            ev.NameEventType = tipoevento;
            _context.EventTypes.Add(ev);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = "Succesfully saved";
            response.Data = tipoevento;
            return Ok(response);
        }

        // DELETE: api/EventTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventType(int id)
        {
            Response response = new();
            if (_context.EventTypes == null)
            {
                response.Message = "Table 'Event Type' doesn't exist";
                return BadRequest(response);
            }
            var eventType = await _context.EventTypes.FindAsync(id);
            if (eventType == null)
            {
                response.Message = $"No Event Type with id: {id}";
                return BadRequest(response);
            }

            _context.EventTypes.Remove(eventType);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = $"Successfully deleted event type with id: {id}";
            response.Data = eventType;
            return Ok(response);
        }

        private bool EventTypeExists(int id)
        {
            return (_context.EventTypes?.Any(e => e.IdEvent == id)).GetValueOrDefault();
        }
    }
}
