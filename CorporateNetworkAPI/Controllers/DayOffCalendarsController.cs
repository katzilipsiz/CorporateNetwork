using CorporateNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DayOffCalendarsController : ControllerBase
{
    private readonly AppDbContext _context;

    public DayOffCalendarsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DayOffCalendar>>> GetDayOffCalendars()
    {
        return await _context.DayOffCalendars.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DayOffCalendar>> GetDayOffCalendar(int id)
    {
        var dayOffCalendar = await _context.DayOffCalendars.FindAsync(id);

        if (dayOffCalendar == null)
        {
            return NotFound();
        }

        return dayOffCalendar;
    }

    [HttpPost]
    public async Task<ActionResult<DayOffCalendar>> PostDayOffCalendar(DayOffCalendar dayOffCalendar)
    {
        _context.DayOffCalendars.Add(dayOffCalendar);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDayOffCalendar", new { id = dayOffCalendar.DayOffCode }, dayOffCalendar);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDayOffCalendar(int id, DayOffCalendar dayOffCalendar)
    {
        if (id != dayOffCalendar.DayOffCode)
        {
            return BadRequest();
        }

        _context.Entry(dayOffCalendar).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DayOffCalendarExists(id))
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
    public async Task<IActionResult> DeleteDayOffCalendar(int id)
    {
        var dayOffCalendar = await _context.DayOffCalendars.FindAsync(id);
        if (dayOffCalendar == null)
        {
            return NotFound();
        }

        _context.DayOffCalendars.Remove(dayOffCalendar);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DayOffCalendarExists(int id)
    {
        return _context.DayOffCalendars.Any(e => e.DayOffCode == id);
    }
}