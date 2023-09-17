using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using barraca.Models;

namespace barraca.Controllers;

[ApiController]
[Route("[controller]")]
public class ReplenishmentController : Controller {
    private readonly BarracaContext _context;

    public ReplenishmentController(BarracaContext context) {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<Replenishment>> Get(Guid uuid) {
        var replenishment = await _context.Replenishments.Where(
            r => r.Uuid == uuid
        ).FirstOrDefaultAsync();

        if(replenishment == null) {
            return NotFound();
        }

        return replenishment;
    }

    [HttpGet("/replenishments")]
    public async Task<ActionResult<IEnumerable<Replenishment>>> Get() {
        var replenishment = await _context.Replenishments.ToListAsync();

        return replenishment;
    }

    [HttpPost]
    public async Task<ActionResult<Replenishment>> Post(Guid productUuid, int quantity) {
        var product = await _context.Products.Where(
            p => p.Uuid == productUuid
        ).FirstOrDefaultAsync();

        if(product == null) {
            return BadRequest();
        }

        Replenishment replenishment = new(product.Id, quantity);

        _context.Replenishments.Add(replenishment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { replenishment.Id }, replenishment);
    }
}
