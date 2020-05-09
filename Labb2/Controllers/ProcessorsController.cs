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
    public class ProcessorsController : ControllerBase
    {
        private readonly Lab2LibraryContext _context;

        public ProcessorsController(Lab2LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Processors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Processor>>> GetCPU()
        {
            return await _context.CPU.ToListAsync();
        }

        // GET: api/Processors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Processor>> GetProcessor(int id)
        {
            var processor = await _context.CPU.FindAsync(id);

            if (processor == null)
            {
                return NotFound();
            }

            return processor;
        }

        // PUT: api/Processors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcessor(int id, Processor processor)
        {
            if (id != processor.Id)
            {
                return BadRequest();
            }

            _context.Entry(processor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessorExists(id))
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

        // POST: api/Processors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Processor>> PostProcessor(Processor processor)
        {
            _context.CPU.Add(processor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcessor", new { id = processor.Id }, processor);
        }

        // DELETE: api/Processors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Processor>> DeleteProcessor(int id)
        {
            var processor = await _context.CPU.FindAsync(id);
            if (processor == null)
            {
                return NotFound();
            }

            _context.CPU.Remove(processor);
            await _context.SaveChangesAsync();

            return processor;
        }

        private bool ProcessorExists(int id)
        {
            return _context.CPU.Any(e => e.Id == id);
        }
    }
}
