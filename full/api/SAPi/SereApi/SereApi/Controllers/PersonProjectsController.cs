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
    public class PersonProjectsController : ControllerBase
    {
        private readonly SereDbContext _context = new();

        // GET: api/PersonProjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonProject>>> GetPersonProjects()
        {
            Response response = new();
            try
            {
                if (_context.PersonProjects == null)
                {
                    response.Message = "Table 'PersonProject' doesn't exist";
                    return NotFound(response);
                }
                var personProjects = await _context.PersonProjects.Select(x => new
                {
                    id = x.IdPersonProject,
                    idPerson = x.IdPerson,
                    idProject = x.IdProject
                }).ToListAsync();
                if (personProjects != null)
                {
                    if (personProjects.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = personProjects;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // GET: api/PersonProjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonProject>> GetPersonProject(int id)
        {
            if (_context.PersonProjects == null)
            {
                return NotFound();
            }
            var personProject = await _context.PersonProjects.FindAsync(id);

            if (personProject == null)
            {
                return NotFound();
            }

            return personProject;
        }

        // PUT: api/PersonProjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonProject(int id, PersonProject personProject)
        {
            if (id != personProject.IdPersonProject)
            {
                return BadRequest();
            }

            _context.Entry(personProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonProjectExists(id))
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

        // POST: api/PersonProjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonProject>> PostPersonProject( int idperson, int idproject)
        {
            Response response = new();
            if (_context.PersonProjects == null)
            {
                response.Message = "No se pudo crear la tabla";
                return NotFound(response);
            }
            PersonProject PerPro = new();
            PerPro.IdPerson = idperson;
            PerPro.IdProject = idproject;
            response.Success = true;
            response.Message = "Succesfully saved";


            _context.PersonProjects.Add(PerPro);
            await _context.SaveChangesAsync();
            return Ok(response);
            
        }

        // DELETE: api/PersonProjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonProject(int id)
        {
            Response response = new();
            if (_context.PersonProjects == null)
            {
                response.Message = "Table 'PersonProject' doesn't exist";
                return BadRequest(response);
            }
            var personProject = await _context.PersonProjects.FindAsync(id);
            if (personProject == null)
            {
                response.Message = $"No PersonProject with id: {id}";
                return BadRequest(response);
            }

            _context.PersonProjects.Remove(personProject);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = $"Successfully deleted PersonProject with id: {id}";
            response.Data = personProject;
            return Ok(response);
        }

        private bool PersonProjectExists(int id)
        {
            return (_context.PersonProjects?.Any(e => e.IdPersonProject == id)).GetValueOrDefault();
        }
    }
}
