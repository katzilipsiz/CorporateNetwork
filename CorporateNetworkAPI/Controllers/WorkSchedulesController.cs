using CorporateNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkSchedulesController : ControllerBase
{
    private readonly AppDbContext _context;

    public WorkSchedulesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkSchedule>>> GetWorkSchedules()
    {
        return await _context.WorkSchedules.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WorkSchedule>> GetWorkSchedule(int id)
    {
        var workSchedule = await _context.WorkSchedules.FindAsync(id);

        if (workSchedule == null)
        {
            return NotFound();
        }

        return workSchedule;
    }

    [HttpPost]
    public async Task<ActionResult<WorkSchedule>> PostWorkSchedule(WorkSchedule workSchedule)
    {
        _context.WorkSchedules.Add(workSchedule);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetWorkSchedule", new { id = workSchedule.ScheduleCode }, workSchedule);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutWorkSchedule(int id, WorkSchedule workSchedule)
    {
        if (id != workSchedule.ScheduleCode)
        {
            return BadRequest();
        }

        _context.Entry(workSchedule).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!WorkScheduleExists(id))
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
    public async Task<IActionResult> DeleteWorkSchedule(int id)
    {
        var workSchedule = await _context.WorkSchedules.FindAsync(id);
        if (workSchedule == null)
        {
            return NotFound();
        }

        _context.WorkSchedules.Remove(workSchedule);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool WorkScheduleExists(int id)
    {
        return _context.WorkSchedules.Any(e => e.ScheduleCode == id);
    }
}