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
    public class ProductoWsController : ControllerBase
    {
        private readonly TruperContext _context;

        public ProductoWsController(TruperContext context)
        {
            _context = context;
        }

        // GET: api/ProductoWs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoW>>> GetProductoWs()
        {
            return await _context.ProductoWs.ToListAsync();
        }

        // GET: api/ProductoWs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoW>> GetProductoW(string id)
        {
            var productoW = await _context.ProductoWs.FindAsync(id);

            if (productoW == null)
            {
                return NotFound();
            }

            return productoW;
        }

        // PUT: api/ProductoWs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductoW(string id, ProductoW productoW)
        {
            if (id != productoW.Sku)
            {
                return BadRequest();
            }

            _context.Entry(productoW).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoWExists(id))
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

        // POST: api/ProductoWs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductoW>> PostProductoW(ProductoW productoW)
        {
            _context.ProductoWs.Add(productoW);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductoWExists(productoW.Sku))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductoW", new { id = productoW.Sku }, productoW);
        }

        // DELETE: api/ProductoWs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductoW(string id)
        {
            var productoW = await _context.ProductoWs.FindAsync(id);
            if (productoW == null)
            {
                return NotFound();
            }

            _context.ProductoWs.Remove(productoW);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoWExists(string id)
        {
            return _context.ProductoWs.Any(e => e.Sku == id);
        }
    }
}
