using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cats.Models;

namespace Cats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly CatContext _context;

        public CatController(CatContext context)
        {
            _context = context;
        }

        // GET: api/Cat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cat>>> GetCat()
        {
            return await _context.Cats.ToListAsync();
        }

        // GET: api/Cat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cat>> GetCat(long id)
        {
            var cat = await _context.Cats.FindAsync(id);

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        // PUT: api/Cat/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCat(long id, Cat cat)
        {
            if (id != cat.Id)
            {
                return BadRequest();
            }

            _context.Entry(cat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatExists(id))
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

        // POST: api/Cat
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cat>> PostCat(Cat cat)
        {
            _context.Cats.Add(cat);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCat), new { id = cat.Id }, cat);
        }

        // DELETE: api/Cat/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCat(long id)
        {
            var cat = await _context.Cats.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }

            _context.Cats.Remove(cat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatExists(long id)
        {
            return _context.Cats.Any(e => e.Id == id);
        }
    }
}
