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
    public class PersonasController : ControllerBase
    {
        SEREdbContext _context = new SEREdbContext();
        
        [HttpGet]
        public async Task<IActionResult> GetPersonas()
        {
            Response resp = new Response();
            try
            {
                if (_context.Personas == null)
                {
                    resp.Message = "No encontro la pagina";
                    return NotFound(resp);
                }
                var personas = await _context.Personas.Select(x => new
                {
                    id = x.IdPersona,
                    nombre = x.Nombre,
                    apellido = x.Apellido,
                    email = x.Email,
                    telefono = x.Fono
                }).ToListAsync();
                if (personas != null)
                {
                    if (personas.Count == 0)
                        resp.Message = "No hay datos";
                    resp.Sucess = true;
                    resp.Data = personas;
                }
                return Ok(resp);
            }
            catch (Exception ex)
            {
                resp.Message = ex.ToString();
                return BadRequest(resp);    
            }
          
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            if (_context.Personas == null)
            {
                return NotFound();
            }
            var persona = await _context.Personas.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // PUT: api/Personas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona persona)
        {
            if (id != persona.IdPersona)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        // POST: api/Personas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            if (_context.Personas == null)
            {
                return Problem("Entity set 'SEREdbContext.Personas'  is null.");
            }
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.IdPersona }, persona);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            if (_context.Personas == null)
            {
                return NotFound();
            }
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaExists(int id)
        {
            return (_context.Personas?.Any(e => e.IdPersona == id)).GetValueOrDefault();
        }
    }
}
