using CorporateNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacationCalendarsController : ControllerBase
{
    private readonly AppDbContext _context;

    public VacationCalendarsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VacationCalendar>>> GetVacationCalendars()
    {
        return await _context.VacationCalendars.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VacationCalendar>> GetVacationCalendar(int id)
    {
        var vacationCalendar = await _context.VacationCalendars.FindAsync(id);

        if (vacationCalendar == null)
        {
            return NotFound();
        }

        return vacationCalendar;
    }

    [HttpPost]
    public async Task<ActionResult<VacationCalendar>> PostVacationCalendar(VacationCalendar vacationCalendar)
    {
        _context.VacationCalendars.Add(vacationCalendar);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetVacationCalendar", new { id = vacationCalendar.VacationCode }, vacationCalendar);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutVacationCalendar(int id, VacationCalendar vacationCalendar)
    {
        if (id != vacationCalendar.VacationCode)
        {
            return BadRequest();
        }

        _context.Entry(vacationCalendar).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VacationCalendarExists(id))
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
    public async Task<IActionResult> DeleteVacationCalendar(int id)
    {
        var vacationCalendar = await _context.VacationCalendars.FindAsync(id);
        if (vacationCalendar == null)
        {
            return NotFound();
        }

        _context.VacationCalendars.Remove(vacationCalendar);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VacationCalendarExists(int id)
    {
        return _context.VacationCalendars.Any(e => e.VacationCode == id);
    }
}