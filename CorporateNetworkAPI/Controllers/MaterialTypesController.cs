using CorporateNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaterialTypesController : ControllerBase
{
    private readonly AppDbContext _context;

    public MaterialTypesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MaterialType>>> GetMaterialTypes()
    {
        return await _context.MaterialTypes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MaterialType>> GetMaterialType(int id)
    {
        var materialType = await _context.MaterialTypes.FindAsync(id);

        if (materialType == null)
        {
            return NotFound();
        }

        return materialType;
    }

    [HttpPost]
    public async Task<ActionResult<MaterialType>> PostMaterialType(MaterialType materialType)
    {
        _context.MaterialTypes.Add(materialType);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMaterialType", new { id = materialType.TypeCode }, materialType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMaterialType(int id, MaterialType materialType)
    {
        if (id != materialType.TypeCode)
        {
            return BadRequest();
        }

        _context.Entry(materialType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MaterialTypeExists(id))
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
    public async Task<IActionResult> DeleteMaterialType(int id)
    {
        var materialType = await _context.MaterialTypes.FindAsync(id);
        if (materialType == null)
        {
            return NotFound();
        }

        _context.MaterialTypes.Remove(materialType);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MaterialTypeExists(int id)
    {
        return _context.MaterialTypes.Any(e => e.TypeCode == id);
    }
}