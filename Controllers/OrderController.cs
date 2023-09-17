using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using barraca.Models;
using barraca.Types;

[ApiController]
[Route("[controller]")]
public class OrderController : Controller {
    private readonly BarracaContext _context;

    public OrderController(BarracaContext context) {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<Order>> Get(Guid uuid) {
        var order = await _context.Orders.Where(
            o => o.Uuid == uuid
        ).FirstOrDefaultAsync();

        if(order == null) {
            return NotFound();
        }

        return order;
    }

    [HttpGet("/orders")]
    public async Task<ActionResult<IEnumerable<Order>>> Get() {
        var orders = await _context.Orders.ToListAsync();

        return orders;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> Post(Guid customerUuid, PaymentState state) {
        var customer = await _context.Customers.Where(
            c => c.Uuid == customerUuid
        ).FirstOrDefaultAsync();

        if(customer == null) {
            return BadRequest();
        }

        Order order = new(customer.Id, state);

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { order.Id }, order);
    }

    [HttpPut]
    public async Task<ActionResult<Order>> Patch(Guid uuid, [FromBody] Order update) {
        var order = await _context.Orders.Where(
            o => o.Uuid == uuid
        ).FirstOrDefaultAsync();

        if(order == null) {
            return BadRequest();
        }

        order.Payment = update.Payment;
        await _context.SaveChangesAsync();

        return Ok(order);
    }
}