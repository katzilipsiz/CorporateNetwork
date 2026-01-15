using CorporateNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MainDepartmentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public MainDepartmentsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MainDepartment>>> GetMainDepartments()
    {
        return await _context.MainDepartments.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MainDepartment>> GetMainDepartment(int id)
    {
        var mainDepartment = await _context.MainDepartments.FindAsync(id);

        if (mainDepartment == null)
        {
            return NotFound();
        }

        return mainDepartment;
    }

    [HttpPost]
    public async Task<ActionResult<MainDepartment>> PostMainDepartment(MainDepartment mainDepartment)
    {
        _context.MainDepartments.Add(mainDepartment);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMainDepartment", new { id = mainDepartment.MainDepartmentCode }, mainDepartment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMainDepartment(int id, MainDepartment mainDepartment)
    {
        if (id != mainDepartment.MainDepartmentCode)
        {
            return BadRequest();
        }

        _context.Entry(mainDepartment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MainDepartmentExists(id))
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
    public async Task<IActionResult> DeleteMainDepartment(int id)
    {
        var mainDepartment = await _context.MainDepartments.FindAsync(id);
        if (mainDepartment == null)
        {
            return NotFound();
        }

        _context.MainDepartments.Remove(mainDepartment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MainDepartmentExists(int id)
    {
        return _context.MainDepartments.Any(e => e.MainDepartmentCode == id);
    }
}