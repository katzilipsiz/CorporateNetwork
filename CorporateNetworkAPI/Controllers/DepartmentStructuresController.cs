using CorporateNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentStructuresController : ControllerBase
{
    private readonly AppDbContext _context;

    public DepartmentStructuresController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentStructure>>> GetDepartmentStructures()
    {
        return await _context.DepartmentStructures.ToListAsync();
    }

    [HttpGet("{departmentCode}/{personalNumber}/{positionCode}")]
    public async Task<ActionResult<DepartmentStructure>> GetDepartmentStructure(int departmentCode, int personalNumber, int positionCode)
    {
        var departmentStructure = await _context.DepartmentStructures
            .FirstOrDefaultAsync(ds => ds.DepartmentCode == departmentCode
                                    && ds.PersonalNumber == personalNumber
                                    && ds.PositionCode == positionCode);

        if (departmentStructure == null)
        {
            return NotFound();
        }

        return departmentStructure;
    }

    [HttpPost]
    public async Task<ActionResult<DepartmentStructure>> PostDepartmentStructure(DepartmentStructure departmentStructure)
    {
        _context.DepartmentStructures.Add(departmentStructure);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDepartmentStructure", new
        {
            departmentCode = departmentStructure.DepartmentCode,
            personalNumber = departmentStructure.PersonalNumber,
            positionCode = departmentStructure.PositionCode
        }, departmentStructure);
    }

    [HttpPut("{departmentCode}/{personalNumber}/{positionCode}")]
    public async Task<IActionResult> PutDepartmentStructure(int departmentCode, int personalNumber, int positionCode, DepartmentStructure departmentStructure)
    {
        if (departmentCode != departmentStructure.DepartmentCode ||
            personalNumber != departmentStructure.PersonalNumber ||
            positionCode != departmentStructure.PositionCode)
        {
            return BadRequest();
        }

        _context.Entry(departmentStructure).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DepartmentStructureExists(departmentCode, personalNumber, positionCode))
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

    [HttpDelete("{departmentCode}/{personalNumber}/{positionCode}")]
    public async Task<IActionResult> DeleteDepartmentStructure(int departmentCode, int personalNumber, int positionCode)
    {
        var departmentStructure = await _context.DepartmentStructures
            .FirstOrDefaultAsync(ds => ds.DepartmentCode == departmentCode
                                    && ds.PersonalNumber == personalNumber
                                    && ds.PositionCode == positionCode);

        if (departmentStructure == null)
        {
            return NotFound();
        }

        _context.DepartmentStructures.Remove(departmentStructure);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DepartmentStructureExists(int departmentCode, int personalNumber, int positionCode)
    {
        return _context.DepartmentStructures.Any(e => e.DepartmentCode == departmentCode
                                                   && e.PersonalNumber == personalNumber
                                                   && e.PositionCode == positionCode);
    }
}