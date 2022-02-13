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
    public class DirectorController : ControllerBase
    {
        private readonly ActividadDiagnosticoContext _context;

        public DirectorController(ActividadDiagnosticoContext context)
        {
            _context = context;
        }

        // GET: api/Director
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Director>>> GetDirector()
        {
            return await _context.Director.ToListAsync();
        }

        // POST: api/Director
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Director>> PostDirector(Director director)
        {
            _context.Director.Add(director);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirector", new { id = director.DirectorId }, director);
        }

    }
}
