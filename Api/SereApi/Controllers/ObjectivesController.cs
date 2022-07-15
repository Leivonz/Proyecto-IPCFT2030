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
    public class ObjectivesController : ControllerBase
    {
        private readonly SereDbContext _context = new();


        // GET: api/Objectives
        [HttpGet]
        public async Task<IActionResult> GetObjectives()
        {
            Response response = new();
            try
            {
                if (_context.Objectives == null)
                {
                    response.Message = "Table 'Objectives' doesn't exist";
                    return NotFound(response);
                }
                var Objectives = await _context.Objectives.Select(x => new
                {
                    id = x.IdObjective,
                    name = x.NameObjective,
                    indicador = x.IndicadorObjective,
                    metas = x.MetasObjective,
                    objective = x.ObjectiveObjective
                }).ToListAsync();
                if (Objectives != null)
                {
                    if (Objectives.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = Objectives;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // GET: api/Objectives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Objective>> GetObjective(int id)
        {
            Response response = new();
            try
            {
                if (_context.Objectives == null)
                {
                    response.Message = "Table 'Objectives' doesn't exist";
                    return NotFound(response);
                }
                var findObjective = await _context.EventTypes.FindAsync(id);
                if (findObjective == null)
                {
                    response.Message = $"Objective with Id: {id} not found";
                    return NotFound(response);
                }
                if (findObjective != null)
                {
                    response.Success = true;
                    response.Data = findObjective;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }
        // PUT: api/Objectives/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjective(int id, Objective objective)
        {
            if (id != objective.IdObjective)
            {
                return BadRequest();
            }

            _context.Entry(objective).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectiveExists(id))
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

        // POST: api/Objectives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Objective>> PostObjective(string nombreObjetivo, string indicador, string metas, string objetivo)
        {
            Response response = new();
            if (_context.Objectives == null)
            {
                response.Message = "Entity set 'SereDbContext.Objectives'  is null.";
                return NotFound(response);
            }
            Objective o = new();
            o.NameObjective = nombreObjetivo;
            o.IndicadorObjective = indicador;
            o.MetasObjective = metas;
            o.ObjectiveObjective = objetivo;
            _context.Objectives.Add(o);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = "Succesfuly saved";
            return Ok(response);
        }

        // DELETE: api/Objectives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjective(int id)
        {
            Response response = new();
            if (_context.Objectives == null)
            {
                response.Message = "Table 'Objective' doesn't exist";
                return BadRequest(response);
            }
            var objective = await _context.Objectives.FindAsync(id);
            if (objective == null)
            {
                response.Message = $"No Objective with id: {id}";
                return BadRequest(response);
            }

            _context.Objectives.Remove(objective);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = $"Successfully deleted objective with id: {id}";
            response.Data = objective;
            return Ok(response);

        }

        private bool ObjectiveExists(int id)
        {
            return (_context.Objectives?.Any(e => e.IdObjective == id)).GetValueOrDefault();
        }
    }
}