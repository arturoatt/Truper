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
    public class PedidosWsController : ControllerBase
    {
        private readonly TruperContext _context;

        public PedidosWsController(TruperContext context)
        {
            _context = context;
        }

        // GET: api/PedidosWs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidosW>>> GetPedidosWs()
        {
            return await _context.PedidosWs.ToListAsync();
        }

        // GET: api/PedidosWs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidosW>> GetPedidosW(int id)
        {
            var pedidosW = await _context.PedidosWs.FindAsync(id);

            if (pedidosW == null)
            {
                return NotFound();
            }

            return pedidosW;
        }

        // PUT: api/PedidosWs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidosW(int id, PedidosW pedidosW)
        {
            if (id != pedidosW.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedidosW).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidosWExists(id))
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

        // POST: api/PedidosWs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PedidosW>> PostPedidosW(PedidosW pedidosW)
        {
            _context.PedidosWs.Add(pedidosW);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidosW", new { id = pedidosW.Id }, pedidosW);
        }

        // DELETE: api/PedidosWs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidosW(int id)
        {
            var pedidosW = await _context.PedidosWs.FindAsync(id);
            if (pedidosW == null)
            {
                return NotFound();
            }

            _context.PedidosWs.Remove(pedidosW);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidosWExists(int id)
        {
            return _context.PedidosWs.Any(e => e.Id == id);
        }
    }
}
