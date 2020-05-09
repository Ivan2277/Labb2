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
    public class LaptopFeaturesController : ControllerBase
    {
        private readonly Lab2LibraryContext _context;

        public LaptopFeaturesController(Lab2LibraryContext context)
        {
            _context = context;
        }

        // GET: api/LaptopFeatures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LaptopFeatures>>> GetLaptopFeatures()
        {
            return await _context.LaptopFeatures.ToListAsync();
        }

        // GET: api/LaptopFeatures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LaptopFeatures>> GetLaptopFeatures(int id)
        {
            var laptopFeatures = await _context.LaptopFeatures.FindAsync(id);

            if (laptopFeatures == null)
            {
                return NotFound();
            }

            return laptopFeatures;
        }

        // PUT: api/LaptopFeatures/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLaptopFeatures(int id, LaptopFeatures laptopFeatures)
        {
            if (id != laptopFeatures.Id)
            {
                return BadRequest();
            }

            _context.Entry(laptopFeatures).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaptopFeaturesExists(id))
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

        // POST: api/LaptopFeatures
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LaptopFeatures>> PostLaptopFeatures(LaptopFeatures laptopFeatures)
        {
            _context.LaptopFeatures.Add(laptopFeatures);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLaptopFeatures", new { id = laptopFeatures.Id }, laptopFeatures);
        }

        // DELETE: api/LaptopFeatures/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LaptopFeatures>> DeleteLaptopFeatures(int id)
        {
            var laptopFeatures = await _context.LaptopFeatures.FindAsync(id);
            if (laptopFeatures == null)
            {
                return NotFound();
            }

            _context.LaptopFeatures.Remove(laptopFeatures);
            await _context.SaveChangesAsync();

            return laptopFeatures;
        }

        private bool LaptopFeaturesExists(int id)
        {
            return _context.LaptopFeatures.Any(e => e.Id == id);
        }
    }
}
