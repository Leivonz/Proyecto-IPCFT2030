using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SereApi.Models;
using System.IdentityModel.Tokens.Jwt;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SereApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SereDbContext _context = new();
        // GET: api/<LoginController>
        [HttpGet]
        public async Task<IActionResult> GetPersonasLogin()
        {
            Response response = new();
            try
            {
                if (_context.People == null)
                {
                    response.Message = "Table 'Person' doesn't exist";
                    return NotFound(response);
                }
                var people = await _context.People.Select(x => new
                {
                    email = x.EmailPerson,
                    pass = x.PasswordPerson,
                }).ToListAsync();
                if (people != null)
                {
                    if (people.Count == 0)
                        response.Message = "No data";
                    response.Success = true;
                    response.Data = people;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(String pass, String correo)
        {
            Response response = new();
            if (_context.People == null)
            {
                response.Message = "Table 'People' doesn't exist";
                return NotFound(response);
            }
            Person p = new();
            p.PasswordPerson = pass;
            p.EmailPerson = correo;

            _context.People.Add(p);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = "Succesfully saved";
            return Ok(response);
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
