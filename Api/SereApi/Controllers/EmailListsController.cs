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
    public class EmailListsController : ControllerBase
    {
        private readonly SereDbContext _context = new();

        // GET: api/EmailLists
        [HttpGet]
        public async Task<IActionResult> GetEmailLists()
        {
            Response response = new();
            try
            {
                if (_context.EmailLists == null)
                {
                    response.Message = "Table 'EmailLists' doesn't exist";
                    return NotFound(response);
                }
                var emails = await _context.EmailLists.Select(x => new
                {
                    id = x.IdEmail,
                    email = x.Email,
                }).ToListAsync();
                if (emails != null)
                {
                    if (emails.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = emails;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // GET: api/EmailLists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmailList(int id)
        {
            Response response = new();
            try
            {
                if (_context.EmailLists == null)
                {
                    response.Message = "Table doesnt exist";
                    return NotFound(response);
                }
                var findEmail = await _context.EmailLists.FindAsync(id);
                if (findEmail == null)
                {
                    response.Message = $"Email with Id: {id} not found";
                    return NotFound(response);
                }
                if (findEmail != null)
                {
                    response.Success = true;
                    response.Data = findEmail;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }
        // PUT: api/EmailLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmailList(int id, EmailList emailList)
        {
            if (id != emailList.IdEmail)
            {
                return BadRequest();
            }

            _context.Entry(emailList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailListExists(id))
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

        // POST: api/EmailLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmailList>> PostEmailList(String emailList)
        {
            Response response = new();
            if (_context.EmailLists == null)
            {
                //return Problem("Entity set 'SereDbContext.Countries'  is null.");
                response.Message = "Table 'EmailLists' doesn't exist";
                return NotFound(response);
            }
            EmailList email = new();
            email.Email = emailList;
            _context.EmailLists.Add(email);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = "Succesfully saved";
            response.Data = email;
            return Ok(response);
        }
        // DELETE: api/EmailLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmailList(int id)
        {
            Response response = new();
            if (_context.EmailLists == null)
            {
                response.Message = "Table 'EmailLists' doesn't exist";
                return NotFound(response);

            }
            var email = await _context.EmailLists.FindAsync(id);
            if (email == null)
            {
                response.Message = $"No email with id: {id}";
                return NotFound(response);
            }

            _context.EmailLists.Remove(email);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = $"Successfully deleted email with id: {id}";
            response.Data = email;
            return Ok(response);
        }

        private bool EmailListExists(int id)
        {
            return (_context.EmailLists?.Any(e => e.IdEmail == id)).GetValueOrDefault();
        }
    }
}
