using barraca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class ShopController : Controller {
    private readonly BarracaContext _context;

    public ShopController(BarracaContext context) {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Shop>> Post(Guid productUuid, int quantity, Guid orderUuid) {
        var product = await _context.Products.Where(
            p => p.Uuid == productUuid
        ).FirstOrDefaultAsync();

        var order = await _context.Orders.Where(
            o => o.Uuid == orderUuid
        ).FirstOrDefaultAsync();

        if(order == null || product == null) {
            return BadRequest();
        }

        Shop shop = new(product.Id, quantity, order.Id);

        _context.Shops.Add(shop);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Post", new { shop.Id }, shop);
    }
}