using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.API.Data;

namespace ClinicaOdontologica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultorioController : ControllerBase
    {
        private readonly ClinicaOdontologicaAPIContext _context;

        public ConsultorioController(ClinicaOdontologicaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Consultorio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consultorio>>> GetConsultorio()
        {
            return await _context.Consultorio.ToListAsync();
        }

        // GET: api/Consultorio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consultorio>> GetConsultorio(int id)
        {
            var consultorio = await _context.Consultorio.FindAsync(id);

            if (consultorio == null)
            {
                return NotFound();
            }

            return consultorio;
        }

        // PUT: api/Consultorio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultorio(int id, Consultorio consultorio)
        {
            if (id != consultorio.IdConsultorio)
            {
                return BadRequest();
            }

            _context.Entry(consultorio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultorioExists(id))
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

        // POST: api/Consultorio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Consultorio>> PostConsultorio(Consultorio consultorio)
        {
            _context.Consultorio.Add(consultorio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsultorio", new { id = consultorio.IdConsultorio }, consultorio);
        }

        // DELETE: api/Consultorio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultorio(int id)
        {
            var consultorio = await _context.Consultorio.FindAsync(id);
            if (consultorio == null)
            {
                return NotFound();
            }

            _context.Consultorio.Remove(consultorio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsultorioExists(int id)
        {
            return _context.Consultorio.Any(e => e.IdConsultorio == id);
        }
    }
}
