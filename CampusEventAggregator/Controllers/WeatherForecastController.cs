using CampusEventAggregator.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CampusEventAggregator.Models;

namespace ProductManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampusEventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CampusEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/campusevents
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _context.Events.ToListAsync();
            return Ok(events);
        }

        // GET: api/Events/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var campusEvent = await _context.Events.FindAsync(id);
            if (campusEvent == null) return NotFound();
            return Ok(campusEvent);
        }

        // POST: api/Events
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Event campusEvent)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Events.Add(campusEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = campusEvent.Id }, campusEvent);
        }

        // PUT: api/Events/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Event updated)
        {
            var campusEvent = await _context.Events.FindAsync(id);
            if (campusEvent == null) return NotFound();

            campusEvent.Title = updated.Title;
            campusEvent.Description = updated.Description;
            campusEvent.Date = updated.Date;
            campusEvent.Location = updated.Location;
            campusEvent.Category = updated.Category;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Events/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var campusEvent = await _context.Events.FindAsync(id);
            if (campusEvent == null) return NotFound();

            _context.Events.Remove(campusEvent);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

