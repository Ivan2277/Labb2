using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Labb2.Models;

namespace Labb2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopsController : ControllerBase
    {
        private readonly Lab2LibraryContext _context;

        public LaptopsController(Lab2LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Laptops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Laptop>>> GetLaptops()
        {
            return await _context.Laptops.ToListAsync();
        }

        // GET: api/Laptops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Laptop>> GetLaptop(int id)
        {
            var laptop = await _context.Laptops.FindAsync(id);

            if (laptop == null)
            {
                return NotFound();
            }

            return laptop;
        }

        // PUT: api/Laptops/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLaptop(int id, Laptop laptop)
        {
            if (id != laptop.Id)
            {
                return BadRequest();
            }

            _context.Entry(laptop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaptopExists(id))
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

        // POST: api/Laptops
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Laptop>> PostLaptop(Laptop laptop)
        {
            _context.Laptops.Add(laptop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLaptop", new { id = laptop.Id }, laptop);
        }

        // DELETE: api/Laptops/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Laptop>> DeleteLaptop(int id)
        {
            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }

            _context.Laptops.Remove(laptop);
            await _context.SaveChangesAsync();

            return laptop;
        }

        private bool LaptopExists(int id)
        {
            return _context.Laptops.Any(e => e.Id == id);
        }
    }
}
