using CorporateNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateNetwork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainingMaterialsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TrainingMaterialsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrainingMaterial>>> GetTrainingMaterials()
    {
        return await _context.TrainingMaterials.ToListAsync();
    }

    [HttpGet("{trainingCode}/{materialCode}")]
    public async Task<ActionResult<TrainingMaterial>> GetTrainingMaterial(int trainingCode, int materialCode)
    {
        var trainingMaterial = await _context.TrainingMaterials
            .FirstOrDefaultAsync(tm => tm.TrainingCode == trainingCode
                                    && tm.MaterialCode == materialCode);

        if (trainingMaterial == null)
        {
            return NotFound();
        }

        return trainingMaterial;
    }

    [HttpPost]
    public async Task<ActionResult<TrainingMaterial>> PostTrainingMaterial(TrainingMaterial trainingMaterial)
    {
        _context.TrainingMaterials.Add(trainingMaterial);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTrainingMaterial", new
        {
            trainingCode = trainingMaterial.TrainingCode,
            materialCode = trainingMaterial.MaterialCode
        }, trainingMaterial);
    }

    [HttpPut("{trainingCode}/{materialCode}")]
    public async Task<IActionResult> PutTrainingMaterial(int trainingCode, int materialCode, TrainingMaterial trainingMaterial)
    {
        if (trainingCode != trainingMaterial.TrainingCode || materialCode != trainingMaterial.MaterialCode)
        {
            return BadRequest();
        }

        _context.Entry(trainingMaterial).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TrainingMaterialExists(trainingCode, materialCode))
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

    [HttpDelete("{trainingCode}/{materialCode}")]
    public async Task<IActionResult> DeleteTrainingMaterial(int trainingCode, int materialCode)
    {
        var trainingMaterial = await _context.TrainingMaterials
            .FirstOrDefaultAsync(tm => tm.TrainingCode == trainingCode
                                    && tm.MaterialCode == materialCode);

        if (trainingMaterial == null)
        {
            return NotFound();
        }

        _context.TrainingMaterials.Remove(trainingMaterial);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TrainingMaterialExists(int trainingCode, int materialCode)
    {
        return _context.TrainingMaterials.Any(e => e.TrainingCode == trainingCode
                                                && e.MaterialCode == materialCode);
    }
}