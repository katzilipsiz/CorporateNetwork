using CorporateNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaterialAuthorsController : ControllerBase
{
    private readonly AppDbContext _context;

    public MaterialAuthorsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MaterialAuthor>>> GetMaterialAuthors()
    {
        return await _context.MaterialAuthors.ToListAsync();
    }

    [HttpGet("{materialCode}/{employeeID}")]
    public async Task<ActionResult<MaterialAuthor>> GetMaterialAuthor(int materialCode, int employeeID)
    {
        var materialAuthor = await _context.MaterialAuthors
            .FirstOrDefaultAsync(ma => ma.MaterialCode == materialCode
                                    && ma.EmployeeID == employeeID);

        if (materialAuthor == null)
        {
            return NotFound();
        }

        return materialAuthor;
    }

    [HttpPost]
    public async Task<ActionResult<MaterialAuthor>> PostMaterialAuthor(MaterialAuthor materialAuthor)
    {
        _context.MaterialAuthors.Add(materialAuthor);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMaterialAuthor", new
        {
            materialCode = materialAuthor.MaterialCode,
            employeeID = materialAuthor.EmployeeID
        }, materialAuthor);
    }

    [HttpPut("{materialCode}/{employeeID}")]
    public async Task<IActionResult> PutMaterialAuthor(int materialCode, int employeeID, MaterialAuthor materialAuthor)
    {
        if (materialCode != materialAuthor.MaterialCode || employeeID != materialAuthor.EmployeeID)
        {
            return BadRequest();
        }

        _context.Entry(materialAuthor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MaterialAuthorExists(materialCode, employeeID))
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

    [HttpDelete("{materialCode}/{employeeID}")]
    public async Task<IActionResult> DeleteMaterialAuthor(int materialCode, int employeeID)
    {
        var materialAuthor = await _context.MaterialAuthors
            .FirstOrDefaultAsync(ma => ma.MaterialCode == materialCode
                                    && ma.EmployeeID == employeeID);

        if (materialAuthor == null)
        {
            return NotFound();
        }

        _context.MaterialAuthors.Remove(materialAuthor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MaterialAuthorExists(int materialCode, int employeeID)
    {
        return _context.MaterialAuthors.Any(e => e.MaterialCode == materialCode
                                              && e.EmployeeID == employeeID);
    }
}