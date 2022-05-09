using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Truper.Entities;
using Truper.Services;

namespace Truper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosWsController : ControllerBase
    {
        private readonly TruperContext _context;

        public UsuariosWsController(TruperContext context)
        {
            _context = context;
        }

        // GET: api/UsuariosWs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuariosW>>> GetUsuariosWs()
        {
            return await _context.UsuariosWs.ToListAsync();
        }

        // GET: api/UsuariosWs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuariosW>> GetUsuariosW(string id)
        {
            var usuariosW = await _context.UsuariosWs.FindAsync(id);

            if (usuariosW == null)
            {
                return NotFound();
            }

            return usuariosW;
        }

        // PUT: api/UsuariosWs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuariosW(string id, UsuariosW usuariosW)
        {
            if (id != usuariosW.Username)
            {
                return BadRequest();
            }

            _context.Entry(usuariosW).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosWExists(id))
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

        // POST: api/UsuariosWs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuariosW>> PostUsuariosW(UsuariosW usuariosW)
        {
            _context.UsuariosWs.Add(usuariosW);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuariosWExists(usuariosW.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuariosW", new { id = usuariosW.Username }, usuariosW);
        }

        // DELETE: api/UsuariosWs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuariosW(string id)
        {
            var usuariosW = await _context.UsuariosWs.FindAsync(id);
            if (usuariosW == null)
            {
                return NotFound();
            }

            _context.UsuariosWs.Remove(usuariosW);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuariosWExists(string id)
        {
            return _context.UsuariosWs.Any(e => e.Username == id);
        }
    }
}
