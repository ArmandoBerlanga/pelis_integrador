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
    public class ProtagonistaController : ControllerBase
    {
        private readonly ActividadDiagnosticoContext _context;

        public ProtagonistaController(ActividadDiagnosticoContext context)
        {
            _context = context;
        }

        // GET: api/Protagonista/5
        [HttpGet("{peliculaID}")]
        public async Task<ActionResult<IEnumerable<Protagonista>>> GetProtagonista(int peliculaID)
        {
            var response = await _context.Protagonista.FromSqlRaw("EXEC dbo.CargarProtagonistas @PeliculaID",
                new SqlParameter("@PeliculaID", peliculaID)
            ).ToListAsync();

            return response;
        }

        // POST: api/Protagonista
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Protagonista>> PostProtagonista(int peliculaID, string nombreProtagonista)
        {
            var response = await _context.Protagonista.FromSqlRaw("EXEC dbo.AgregarPeliculaProtagonista @PeliculaID, @NombreProtagonista",
                new SqlParameter("@PeliculaID", peliculaID),
                new SqlParameter("@NombreProtagonista", nombreProtagonista)
            ).ToListAsync();

         
            return response.FirstOrDefault();
        }

        // DELETE: api/Protagonista/5
        [HttpDelete("{peliculaID}/{protagonistaID}")]
        public async Task<ActionResult<Protagonista>> DeleteProtagonista(int peliculaID, int protagonistaID)
        {
            var response = await _context.Protagonista.FromSqlRaw("EXEC dbo.DeletePeliculaProtagonista @PeliculaID, @ProtagonistaID",
                new SqlParameter("@PeliculaID", peliculaID),
                new SqlParameter("@ProtagonistaID", protagonistaID)
            ).ToListAsync();

            if (response.Count == 0)
                return BadRequest();

            return response.FirstOrDefault();
        }

    }
}
