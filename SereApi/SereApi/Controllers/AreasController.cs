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
    public class AreasController : ControllerBase
    {
        private readonly SereDbContext _context = new();


        // GET: api/Areas
        [HttpGet]
        public async Task<IActionResult> GetAreas()
        {
            Response response = new();
            try
            {
                if (_context.Areas == null)
                {
                    response.Message = "Table 'Areas' doesn't exist";
                    return NotFound(response);
                }
                var areas = await _context.Areas.Select(x => new
                {
                    id = x.IdArea,
                    name = x.NameArea
                }).ToListAsync();
                if (areas != null)
                {
                    if (areas.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = areas;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // GET: api/Areas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> GetArea(int id)
        {
            Response response = new();
            try
            {
                if (_context.Areas == null)
                {
                    response.Message = "Table doesnt exist";
                    return NotFound(response);
                }
                var findArea = await _context.EventTypes.FindAsync(id);
                if (findArea == null)
                {
                    response.Message = $"Event type with Id: {id} not found";
                    return NotFound(response);
                }
                if (findArea != null)
                {
                    response.Success = true;
                    response.Data = findArea;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // PUT: api/Areas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArea(int id, Area area)
        {
            if (id != area.IdArea)
            {
                return BadRequest();
            }

            _context.Entry(area).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaExists(id))
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

        // POST: api/Areas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Area>> PostArea(Area area)
        {
            if (_context.Areas == null)
            {
                return Problem("Entity set 'SereDbContext.Areas'  is null.");
            }
            _context.Areas.Add(area);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArea", new { id = area.IdArea }, area);
        }

        // DELETE: api/Areas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            Response response = new();
            if (_context.Areas == null)
            {
                response.Message = "Table 'Area' doesn't exist";
                return BadRequest(response);
            }
            var area = await _context.Areas.FindAsync(id);
            if (area == null)
            {
                response.Message = $"No Area with id: {id}";
                return BadRequest(response);
            }

            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = $"Successfully deleted area with id: {id}";
            response.Data = area;
            return Ok(response);
        }

        private bool AreaExists(int id)
        {
            return (_context.Areas?.Any(e => e.IdArea == id)).GetValueOrDefault();
        }
    }
}
