using barraca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[Controller]")]
public class ProductController : Controller {
    private readonly BarracaContext _context;

    public ProductController(BarracaContext context) {
        _context = context;
    }

    [HttpGet("")]
    public async Task<ActionResult<Product>> Get(Guid uuid) {
        var product = await _context.Products.Where(
            p => p.Uuid == uuid
        ).FirstOrDefaultAsync();

        if(product == null) {
            return NotFound();
        }

        return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Post(Product product) {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { product.Id }, product);
    }
}
