using CorporateNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventResponsiblesController : ControllerBase
{
    private readonly AppDbContext _context;

    public EventResponsiblesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventResponsible>>> GetEventResponsibles()
    {
        return await _context.EventResponsibles.ToListAsync();
    }

    [HttpGet("{eventCode}/{employeeID}")]
    public async Task<ActionResult<EventResponsible>> GetEventResponsible(int eventCode, int employeeID)
    {
        var eventResponsible = await _context.EventResponsibles
            .FirstOrDefaultAsync(er => er.EventCode == eventCode
                                    && er.EmployeeID == employeeID);

        if (eventResponsible == null)
        {
            return NotFound();
        }

        return eventResponsible;
    }

    [HttpPost]
    public async Task<ActionResult<EventResponsible>> PostEventResponsible(EventResponsible eventResponsible)
    {
        _context.EventResponsibles.Add(eventResponsible);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEventResponsible", new
        {
            eventCode = eventResponsible.EventCode,
            employeeID = eventResponsible.EmployeeID
        }, eventResponsible);
    }

    [HttpPut("{eventCode}/{employeeID}")]
    public async Task<IActionResult> PutEventResponsible(int eventCode, int employeeID, EventResponsible eventResponsible)
    {
        if (eventCode != eventResponsible.EventCode || employeeID != eventResponsible.EmployeeID)
        {
            return BadRequest();
        }

        _context.Entry(eventResponsible).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EventResponsibleExists(eventCode, employeeID))
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

    [HttpDelete("{eventCode}/{employeeID}")]
    public async Task<IActionResult> DeleteEventResponsible(int eventCode, int employeeID)
    {
        var eventResponsible = await _context.EventResponsibles
            .FirstOrDefaultAsync(er => er.EventCode == eventCode
                                    && er.EmployeeID == employeeID);

        if (eventResponsible == null)
        {
            return NotFound();
        }

        _context.EventResponsibles.Remove(eventResponsible);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EventResponsibleExists(int eventCode, int employeeID)
    {
        return _context.EventResponsibles.Any(e => e.EventCode == eventCode
                                                && e.EmployeeID == employeeID);
    }
}