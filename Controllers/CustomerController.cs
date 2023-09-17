using Microsoft.AspNetCore.Mvc;
using barraca.Models;
using Microsoft.EntityFrameworkCore;
using barraca.Types;

namespace barraca.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : Controller {

    private readonly BarracaContext _context;

    public CustomerController(BarracaContext context) {
        _context = context;
    }

    [HttpGet("")]
    public async Task<ActionResult<Customer>> Get(Guid uuid) {
        var customer = await _context.Customers.Where(
            c => c.Uuid == uuid
        ).FirstOrDefaultAsync();

        if(customer == null) {
            return NotFound();
        }

        return customer;
    }

    [HttpGet("email")]
    public async Task<ActionResult<Customer>> GetByEmail(string email) {
        var customer = await _context.Customers.Where(
            c => c.Email == email
        ).FirstOrDefaultAsync();

        if(customer == null) {
            return NotFound();
        }

        return customer;
    }

    [HttpGet("/customers")]
    public async Task<ActionResult<IEnumerable<Customer>>> GetAll() {
        var customers = await _context.Customers.ToListAsync();

        return customers;
    }

    [HttpGet("/debts")]
    public async Task<ActionResult<IEnumerable<Order>>> GetDebts(Guid uuid) {
        var customer = await _context.Customers.Where(
            c => c.Uuid == uuid
        ).FirstOrDefaultAsync();

        if(customer == null) {
            return BadRequest();
        }

        var orders = await _context.Orders.Where(
            o => o.CustomerId == customer.Id && o.Payment == PaymentState.Pending
        ).ToListAsync();

        return orders;
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> Post(Customer customer) {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { customer.Id }, customer);
    }
}
