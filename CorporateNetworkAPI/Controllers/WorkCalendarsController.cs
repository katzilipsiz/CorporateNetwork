using CorporateNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkCalendarsController : ControllerBase
{
    private readonly AppDbContext _context;

    public WorkCalendarsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkCalendar>>> GetWorkCalendars()
    {
        return await _context.WorkCalendars.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WorkCalendar>> GetWorkCalendar(int id)
    {
        var workCalendar = await _context.WorkCalendars.FindAsync(id);

        if (workCalendar == null)
        {
            return NotFound();
        }

        return workCalendar;
    }

    [HttpPost]
    public async Task<ActionResult<WorkCalendar>> PostWorkCalendar(WorkCalendar workCalendar)
    {
        _context.WorkCalendars.Add(workCalendar);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetWorkCalendar", new { id = workCalendar.DayCode }, workCalendar);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutWorkCalendar(int id, WorkCalendar workCalendar)
    {
        if (id != workCalendar.DayCode)
        {
            return BadRequest();
        }

        _context.Entry(workCalendar).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!WorkCalendarExists(id))
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
    public async Task<IActionResult> DeleteWorkCalendar(int id)
    {
        var workCalendar = await _context.WorkCalendars.FindAsync(id);
        if (workCalendar == null)
        {
            return NotFound();
        }

        _context.WorkCalendars.Remove(workCalendar);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool WorkCalendarExists(int id)
    {
        return _context.WorkCalendars.Any(e => e.DayCode == id);
    }
}