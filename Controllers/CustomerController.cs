using Microsoft.AspNetCore.Mvc;
using barraca.Models;
using Microsoft.EntityFrameworkCore;

namespace barraca.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : Controller {

    private readonly BarracaContext _context;

    public CustomerController(BarracaContext context) {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> Get(long id) {
        var customer = await _context.Customers.FindAsync(id);

        if(customer == null) {
            return NotFound();
        }

        return customer;
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> Post(Customer customer) {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = customer.Id}, customer);
    }
}
