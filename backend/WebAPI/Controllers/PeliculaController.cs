using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly ActividadDiagnosticoContext _context;

        public PeliculaController(ActividadDiagnosticoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pelicula>>> GetCategoria()
        {
            return await _context.ListaPelicula.FromSqlRaw("EXEC dbo.CargarListaPeliculas").ToListAsync();
        }

    }
}
