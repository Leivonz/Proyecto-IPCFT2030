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
    public class TipoEventoesController : ControllerBase
    {
        private readonly SEREdbContext _context = new();

        // GET: api/TipoEventoes
        [HttpGet]
        public async Task<IActionResult> GetTipoEventos()
        {
            Response response = new();
            try
            {
                if(_context.TipoEventos == null)
                {
                    response.Message = "No se encuentran tipos de eventos";
                    return NotFound(response);
                }
                var tipos = await _context.TipoEventos.Select(x => new
                {
                    id = x.IdEvento,
                    nombre = x.NombreTipo,
                }).ToListAsync();
                if (tipos != null)
                {
                    if (tipos.Count == 0)
                        response.Message = "No existen datos";
                    response.Sucess = true;
                    response.Data=tipos;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }


        // GET: api/TipoEventoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoEvento>> GetTipoEvento(int id)
        {
          if (_context.TipoEventos == null)
          {
              return NotFound();
          }
            var tipoEvento = await _context.TipoEventos.FindAsync(id);

            if (tipoEvento == null)
            {
                return NotFound();
            }

            return tipoEvento;
        }

        // PUT: api/TipoEventoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoEvento(int id, TipoEvento tipoEvento)
        {
            if (id != tipoEvento.IdEvento)
            {
                return BadRequest();
            }

            _context.Entry(tipoEvento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoEventoExists(id))
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

        // POST: api/TipoEventoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoEvento>> PostTipoEvento(TipoEvento tipoEvento)
        {
          if (_context.TipoEventos == null)
          {
              return Problem("Entity set 'SEREdbContext.TipoEventos'  is null.");
          }
            _context.TipoEventos.Add(tipoEvento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoEventoExists(tipoEvento.IdEvento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoEvento", new { id = tipoEvento.IdEvento }, tipoEvento);
        }

        // DELETE: api/TipoEventoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoEvento(int id)
        {
            if (_context.TipoEventos == null)
            {
                return NotFound();
            }
            var tipoEvento = await _context.TipoEventos.FindAsync(id);
            if (tipoEvento == null)
            {
                return NotFound();
            }

            _context.TipoEventos.Remove(tipoEvento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoEventoExists(int id)
        {
            return (_context.TipoEventos?.Any(e => e.IdEvento == id)).GetValueOrDefault();
        }
    }
}
