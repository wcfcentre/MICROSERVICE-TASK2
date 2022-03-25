using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bookweb.Model;

namespace bookweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        private readonly BookContext _context;

        public booksController(BookContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<book>>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<book>> Getbook(long id)
        {
            var book = await _context.Bookings.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbook(long id, book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bookExists(id))
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

        // POST: api/books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<book>> Postbook(book book)
        {
            _context.Bookings.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getbook", new { id = book.Id }, book);
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletebook(long id)
        {
            var book = await _context.Bookings.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool bookExists(long id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }
    }
}
