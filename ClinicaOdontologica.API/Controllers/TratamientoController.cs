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
    public class TratamientoController : ControllerBase
    {
        private readonly ClinicaOdontologicaAPIContext _context;

        public TratamientoController(ClinicaOdontologicaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Tratamiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tratamiento>>> GetTratamiento()
        {
            return await _context.Tratamiento.ToListAsync();
        }

        // GET: api/Tratamiento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tratamiento>> GetTratamiento(int id)
        {
            var tratamiento = await _context.Tratamiento.FindAsync(id);

            if (tratamiento == null)
            {
                return NotFound();
            }

            return tratamiento;
        }

        // PUT: api/Tratamiento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTratamiento(int id, Tratamiento tratamiento)
        {
            if (id != tratamiento.IdTratamiento)
            {
                return BadRequest();
            }

            _context.Entry(tratamiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TratamientoExists(id))
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

        // POST: api/Tratamiento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tratamiento>> PostTratamiento(Tratamiento tratamiento)
        {
            _context.Tratamiento.Add(tratamiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTratamiento", new { id = tratamiento.IdTratamiento }, tratamiento);
        }

        // DELETE: api/Tratamiento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTratamiento(int id)
        {
            var tratamiento = await _context.Tratamiento.FindAsync(id);
            if (tratamiento == null)
            {
                return NotFound();
            }

            _context.Tratamiento.Remove(tratamiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TratamientoExists(int id)
        {
            return _context.Tratamiento.Any(e => e.IdTratamiento == id);
        }
    }
}
