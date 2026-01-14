using CorporateNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventStatusesController : ControllerBase
{
    private readonly AppDbContext _context;

    public EventStatusesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventStatus>>> GetEventStatuses()
    {
        return await _context.EventStatuses.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventStatus>> GetEventStatus(int id)
    {
        var eventStatus = await _context.EventStatuses.FindAsync(id);

        if (eventStatus == null)
        {
            return NotFound();
        }

        return eventStatus;
    }

    [HttpPost]
    public async Task<ActionResult<EventStatus>> PostEventStatus(EventStatus eventStatus)
    {
        _context.EventStatuses.Add(eventStatus);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEventStatus", new { id = eventStatus.StatusCode }, eventStatus);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEventStatus(int id, EventStatus eventStatus)
    {
        if (id != eventStatus.StatusCode)
        {
            return BadRequest();
        }

        _context.Entry(eventStatus).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EventStatusExists(id))
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
    public async Task<IActionResult> DeleteEventStatus(int id)
    {
        var eventStatus = await _context.EventStatuses.FindAsync(id);
        if (eventStatus == null)
        {
            return NotFound();
        }

        _context.EventStatuses.Remove(eventStatus);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EventStatusExists(int id)
    {
        return _context.EventStatuses.Any(e => e.StatusCode == id);
    }
}