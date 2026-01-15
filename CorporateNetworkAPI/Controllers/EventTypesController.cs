using CorporateNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventTypesController : ControllerBase
{
    private readonly AppDbContext _context;

    public EventTypesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventType>>> GetEventTypes()
    {
        return await _context.EventTypes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventType>> GetEventType(int id)
    {
        var eventType = await _context.EventTypes.FindAsync(id);

        if (eventType == null)
        {
            return NotFound();
        }

        return eventType;
    }

    [HttpPost]
    public async Task<ActionResult<EventType>> PostEventType(EventType eventType)
    {
        _context.EventTypes.Add(eventType);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEventType", new { id = eventType.TypeCode }, eventType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEventType(int id, EventType eventType)
    {
        if (id != eventType.TypeCode)
        {
            return BadRequest();
        }

        _context.Entry(eventType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EventTypeExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEventType(int id)
    {
        var eventType = await _context.EventTypes.FindAsync(id);
        if (eventType == null)
        {
            return NotFound();
        }

        _context.EventTypes.Remove(eventType);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EventTypeExists(int id)
    {
        return _context.EventTypes.Any(e => e.TypeCode == id);
    }
}