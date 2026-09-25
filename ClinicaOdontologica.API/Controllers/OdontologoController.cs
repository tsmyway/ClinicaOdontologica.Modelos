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
    public class OdontologoController : ControllerBase
    {
        private readonly ClinicaOdontologicaAPIContext _context;

        public OdontologoController(ClinicaOdontologicaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Odontologo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Odontologo>>> GetOdontologo()
        {
            return await _context.Odontologo.ToListAsync();
        }

        // GET: api/Odontologo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Odontologo>> GetOdontologo(int id)
        {
            var odontologo = await _context.Odontologo.FindAsync(id);

            if (odontologo == null)
            {
                return NotFound();
            }

            return odontologo;
        }

        // PUT: api/Odontologo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOdontologo(int id, Odontologo odontologo)
        {
            if (id != odontologo.IdOdontologo)
            {
                return BadRequest();
            }

            _context.Entry(odontologo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OdontologoExists(id))
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

        // POST: api/Odontologo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Odontologo>> PostOdontologo(Odontologo odontologo)
        {
            _context.Odontologo.Add(odontologo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOdontologo", new { id = odontologo.IdOdontologo }, odontologo);
        }

        // DELETE: api/Odontologo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOdontologo(int id)
        {
            var odontologo = await _context.Odontologo.FindAsync(id);
            if (odontologo == null)
            {
                return NotFound();
            }

            _context.Odontologo.Remove(odontologo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OdontologoExists(int id)
        {
            return _context.Odontologo.Any(e => e.IdOdontologo == id);
        }
    }
}
