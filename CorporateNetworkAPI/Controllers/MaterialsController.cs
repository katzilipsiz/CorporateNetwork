using CorporateNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaterialsController : ControllerBase
{
    private readonly AppDbContext _context;

    public MaterialsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Material>>> GetMaterials()
    {
        return await _context.Materials.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Material>> GetMaterial(int id)
    {
        var material = await _context.Materials.FindAsync(id);

        if (material == null)
        {
            return NotFound();
        }

        return material;
    }

    [HttpPost]
    public async Task<ActionResult<Material>> PostMaterial(Material material)
    {
        _context.Materials.Add(material);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMaterial", new { id = material.MaterialCode }, material);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMaterial(int id, Material material)
    {
        if (id != material.MaterialCode)
        {
            return BadRequest();
        }

        _context.Entry(material).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MaterialExists(id))
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
    public async Task<IActionResult> DeleteMaterial(int id)
    {
        var material = await _context.Materials.FindAsync(id);
        if (material == null)
        {
            return NotFound();
        }

        _context.Materials.Remove(material);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MaterialExists(int id)
    {
        return _context.Materials.Any(e => e.MaterialCode == id);
    }
}