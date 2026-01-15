using CorporateNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InterviewsController : ControllerBase
{
    private readonly AppDbContext _context;

    public InterviewsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Interview>>> GetInterviews()
    {
        return await _context.Interviews.ToListAsync();
    }

    [HttpGet("{employeeId}/{interviewDateTime}")]
    public async Task<ActionResult<Interview>> GetInterview(int employeeId, DateTime interviewDateTime)
    {
        var interview = await _context.Interviews
            .FirstOrDefaultAsync(i => i.EmployeeID == employeeId && i.InterviewDateTime == interviewDateTime);

        if (interview == null)
        {
            return NotFound();
        }

        return interview;
    }

    [HttpPost]
    public async Task<ActionResult<Interview>> PostInterview(Interview interview)
    {
        _context.Interviews.Add(interview);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetInterview", new
        {
            employeeId = interview.EmployeeID,
            interviewDateTime = interview.InterviewDateTime
        }, interview);
    }

    [HttpPut("{employeeId}/{interviewDateTime}")]
    public async Task<IActionResult> PutInterview(int employeeId, DateTime interviewDateTime, Interview interview)
    {
        if (employeeId != interview.EmployeeID || interviewDateTime != interview.InterviewDateTime)
        {
            return BadRequest();
        }

        _context.Entry(interview).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!InterviewExists(employeeId, interviewDateTime))
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

    [HttpDelete("{employeeId}/{interviewDateTime}")]
    public async Task<IActionResult> DeleteInterview(int employeeId, DateTime interviewDateTime)
    {
        var interview = await _context.Interviews
            .FirstOrDefaultAsync(i => i.EmployeeID == employeeId && i.InterviewDateTime == interviewDateTime);

        if (interview == null)
        {
            return NotFound();
        }

        _context.Interviews.Remove(interview);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool InterviewExists(int employeeId, DateTime interviewDateTime)
    {
        return _context.Interviews.Any(e => e.EmployeeID == employeeId && e.InterviewDateTime == interviewDateTime);
    }
}