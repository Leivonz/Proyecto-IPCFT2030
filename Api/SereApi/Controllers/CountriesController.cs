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
    public class CountriesController : ControllerBase
    {
        private readonly SereDbContext _context = new();

        // GET: api/Countries
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            Response response = new();
            try
            {
                if (_context.Countries == null)
                {
                    response.Message = "Table 'Countries' doesn't exist";
                    return NotFound(response);
                }
                var countries = await _context.Countries.Select(x => new
                {
                    id = x.IdCountry,
                    name = x.NameCountry
                }).ToListAsync();
                if (countries != null)
                {
                    if (countries.Count == 0)
                    {
                        response.Message = "No data";
                    }
                    response.Success = true;
                    response.Data = countries;
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
        public async Task<IActionResult> GetCountry(int id)
        {
            Response response = new();
            try
            {
                if (_context.Countries == null)
                {
                    response.Message = "Table doesnt exist";
                    return NotFound(response);
                }
                var findCountry = await _context.EventTypes.FindAsync(id);
                if (findCountry == null)
                {
                    response.Message = $"Country with Id: {id} not found";
                    return NotFound(response);
                }
                if (findCountry != null)
                {
                    response.Success = true;
                    response.Data = findCountry;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                return BadRequest(response);
            }
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.IdCountry)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(string NameCountry)
        {
            Response response = new();
            if (_context.Countries == null)
            {
                //return Problem("Entity set 'SereDbContext.Countries'  is null.");
                response.Message = "Table 'Countries' doesn't exist";
                return NotFound(response);
            }
            Country country = new();
            country.NameCountry = NameCountry;
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = "Succesfully saved";
            response.Data = NameCountry;
            return Ok(response);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            Response response = new();
            if (_context.Countries == null)
            {
                response.Message = "Table 'Country' doesn't exist";
                return NotFound(response);
                   
            }
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                response.Message = $"No country with id: {id}";
                return NotFound(response);
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = $"Successfully deleted country with id: {id}";
            response.Data = country;
            return Ok(response);
        }

        private bool CountryExists(int id)
        {
            return (_context.Countries?.Any(e => e.IdCountry == id)).GetValueOrDefault();
        }
    }
}
