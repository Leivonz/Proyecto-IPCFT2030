using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SereApi.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace SereApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly SereDbContext _context = new();


        // GET: api/Events
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            Response response = new();
            try
            {
                if (_context.Events == null)
                {
                    response.Message = "Table 'Areas' doesn't exist";
                    return NotFound(response);
                }
                var events = await _context.Events.Select(x => new
                {
                    id = x.IdEvent,
                    name = x.NameEvent,
                    date = x.DateEvent,
                    description = x.DescriptionEvent,
                    idEventType = x.IdEventType,
                    idOrganization = x.IdOrganization
                }).ToListAsync();
                if (events != null)
                {
                    if (events.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = events;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        //TODO: Add Get{id} method?

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.IdEvent)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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
        private readonly IWebHostEnvironment _env;

        public EventsController (IWebHostEnvironment env)
        {
            _env = env;
        }

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent( String name, DateTime date, String description, byte img)
        {
            Response response = new();
            if (_context.Events == null)
            {
                response.Message = "No se encontró la tabla";
                return NotFound(response);
            }
            Event e = new();
            e.NameEvent = name;
            e.DateEvent = date;
            e.DescriptionEvent = description;
            e.ImagenEvento = img;


            _context.Events.Add(e);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = "Succesfully saved";
            return Ok(response);
        }
        [HttpPost("Subir_Archivos")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            return Ok(new {count = files.Count, size, filePath});
        }
        

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            Response response = new();
            if (_context.Events == null)
            {
                response.Message = "Table 'Events' doesn't exist";
                return BadRequest(response);
            }
            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                response.Message = $"No Event with id: {id}";
                return BadRequest(response);
            }

            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = $"Successfully deleted event with id: {id}";
            response.Data = @event;
            return Ok(response);
        }

        private bool EventExists(int id)
        {
            return (_context.Events?.Any(e => e.IdEvent == id)).GetValueOrDefault();
        }
    }
}
