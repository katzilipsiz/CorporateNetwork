using CorporateNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainingCalendarsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TrainingCalendarsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrainingCalendar>>> GetTrainingCalendars()
    {
        return await _context.TrainingCalendars.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TrainingCalendar>> GetTrainingCalendar(int id)
    {
        var trainingCalendar = await _context.TrainingCalendars.FindAsync(id);

        if (trainingCalendar == null)
        {
            return NotFound();
        }

        return trainingCalendar;
    }

    [HttpPost]
    public async Task<ActionResult<TrainingCalendar>> PostTrainingCalendar(TrainingCalendar trainingCalendar)
    {
        _context.TrainingCalendars.Add(trainingCalendar);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTrainingCalendar", new { id = trainingCalendar.TrainingCode }, trainingCalendar);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTrainingCalendar(int id, TrainingCalendar trainingCalendar)
    {
        if (id != trainingCalendar.TrainingCode)
        {
            return BadRequest();
        }

        _context.Entry(trainingCalendar).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TrainingCalendarExists(id))
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
    public async Task<IActionResult> DeleteTrainingCalendar(int id)
    {
        var trainingCalendar = await _context.TrainingCalendars.FindAsync(id);
        if (trainingCalendar == null)
        {
            return NotFound();
        }

        _context.TrainingCalendars.Remove(trainingCalendar);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TrainingCalendarExists(int id)
    {
        return _context.TrainingCalendars.Any(e => e.TrainingCode == id);
    }
}