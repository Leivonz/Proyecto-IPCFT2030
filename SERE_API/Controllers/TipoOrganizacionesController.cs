using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SereApi.Models;

namespace SereApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoOrganizacionesController : ControllerBase
    {
        //private SEREdbContext _context = new SEREdbContext();
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var tipos = await _context.Tipoorganizacions.Select(x => new
        //    {
        //        id = x.IdTipoorganizacion,
        //        tipo = x.Nombre
        //    }).ToList();
        //    return Ok(tipos)
        //}
    }
}
