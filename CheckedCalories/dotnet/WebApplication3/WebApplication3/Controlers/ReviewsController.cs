using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;

namespace WebApplication3.Controlers
{
    [Route("api/[controller]")]
    [EnableCors("VueCorsPolicy")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewsContext _context;

        public ReviewsController(ReviewsContext context)
        {
            _context = context;
        }

        // GET: api/Reviews
        [HttpGet]
        public IEnumerable<Reviews> GetReviews()
        {
            return _context.Reviews;
        }

        // GET: api/Reviews/
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviews([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviews = await _context.Reviews.FindAsync(id);

            if (reviews == null)
            {
                return NotFound();
            }

            return Ok(reviews);
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        [EnableCors("AllowAllOrigins")]
        public async Task<IActionResult> PutReviews([FromRoute] int id, [FromBody] Reviews reviews)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reviews.Id)
            {
                return BadRequest();
            }

            _context.Entry(reviews).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewsExists(id))
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

        // POST: api/Reviews
        [HttpPost]
        public async Task<IActionResult> PostReviews([FromBody] Reviews reviews)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Reviews.Add(reviews);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReviews", new { id = reviews.Id }, reviews);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviews([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(reviews);
            await _context.SaveChangesAsync();

            return Ok(reviews);
        }

        private bool ReviewsExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}