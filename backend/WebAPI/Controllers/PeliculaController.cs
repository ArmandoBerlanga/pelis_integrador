using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using Microsoft.Data.SqlClient;

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
        public async Task<ActionResult<IEnumerable<Pelicula>>> GetPeliculas()
        {
            return await _context.ListaPelicula.FromSqlRaw("EXEC dbo.CargarListaPeliculas").ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<Pelicula>> PostPelicula(Pelicula pelicula)
        {
            await _context.ListaPelicula.FromSqlRaw("EXEC dbo.GuardarPelicula @PeliculaID, @NombrePelicula, @Duracion, @CategoriaID, @DirectorID, @Poster",
                new SqlParameter("@PeliculaID", pelicula.PeliculaId),
                new SqlParameter("@NombrePelicula", pelicula.NombrePelicula),
                new SqlParameter("@Duracion", pelicula.Duracion),
                new SqlParameter("@CategoriaID", pelicula.CategoriaId),
                new SqlParameter("@DirectorID", pelicula.DirectorId),
                new SqlParameter("@Poster", pelicula.Poster)
            ).ToListAsync();

            return CreatedAtAction("GetPelicula", new { id = pelicula.PeliculaId }, pelicula);
        }

    }
}
