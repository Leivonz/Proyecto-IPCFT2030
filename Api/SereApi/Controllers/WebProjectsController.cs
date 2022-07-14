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
    public class WebProjectsController : ControllerBase
    {
        private readonly SereDbContext _context = new();


        // GET: api/WebProjects
        [HttpGet]
        public async Task<IActionResult> GetWebProjects()
        {
            Response response = new();
            try
            {
                if (_context.WebProjects == null)
                {
                    response.Message = "Table 'WebProjects' doesn't exist";
                    return NotFound(response);
                }
                var webProject = await _context.WebProjects.Select(x => new
                {
                    id = x.IdWebProject,
                    name = x.Name,
                    title = x.Title,
                    descrpition = x.Description,
                    statis = x.Status,
                    img = x.Img
                }).ToListAsync();
                if (webProject != null)
                {
                    if (webProject.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = webProject;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWebProject(int id)
        {
            Response response = new();
            try
            {
                if (_context.WebProjects == null)
                {
                    response.Message = "Table doesnt exist";
                    return NotFound(response);
                }
                var findWebProject = await _context.EventTypes.FindAsync(id);
                if (findWebProject == null)
                {
                    response.Message = $"WebProject with Id: {id} not found";
                    return NotFound(response);
                }
                if (findWebProject != null)
                {
                    response.Success = true;
                    response.Data = findWebProject;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // PUT: api/WebProjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWebProject(int id, WebProject webProject)
        {
            if (id != webProject.IdWebProject)
            {
                return BadRequest();
            }

            _context.Entry(webProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebProjectExists(id))
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

        // POST: api/WebProjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WebProject>> PostWebProject(String name,String title, String description, String status, String img)
        {
            Response response = new();
            if (_context.WebProjects == null)
            {
                //return Problem("Entity set 'SereDbContext.Countries'  is null.");
                response.Message = "Table 'WebProject' doesn't exist";
                return NotFound(response);
            }
            WebProject webProject = new();
            webProject.Name = name;
            webProject.Title = title;   
            webProject.Description = description;
            webProject.Status = status;
            webProject.Img = img;
            _context.WebProjects.Add(webProject);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = "Succesfully saved";
            response.Data = webProject;
            return Ok(response);
        }

        // DELETE: api/WebProjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWebProject(int id)
        {
            Response response = new();
            if (_context.WebProjects == null)
            {
                response.Message = "Table 'WebProject' doesn't exist";
                return NotFound(response);

            }
            var webProject = await _context.WebProjects.FindAsync(id);
            if (webProject == null)
            {
                response.Message = $"No Web Project with id: {id}";
                return NotFound(response);
            }

            _context.WebProjects.Remove(webProject);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = $"Successfully deleted Web Project with id: {id}";
            response.Data = webProject;
            return Ok(response);
        }

        private bool WebProjectExists(int id)
        {
            return (_context.WebProjects?.Any(e => e.IdWebProject == id)).GetValueOrDefault();
        }
    }
}
