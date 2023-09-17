using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using barraca.Models;
using System.Diagnostics;

namespace barraca.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : Controller {
    private readonly BarracaContext _context;

    public ProductsController(BarracaContext context) {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> Get() {
        var products = await _context.Products.ToListAsync();

        return products;
    }

    [HttpGet("availables")]
    public async Task<ActionResult<IEnumerable<Stock>>> GetAvailables() {
        /*SELECT Replenishments.ProductId, SUM(Replenishments.Quantity) - SUM(Shops.Quantity) as Stock
        FROM Replenishments
        JOIN Shops
        ON Replenishments.ProductId=Shops.ProductId
        GROUP BY Replenishments.ProductId;*/
        var repByProduct = from rep in _context.Replenishments
                           group rep by rep.ProductId into grupo
                           select new {
                               productId = grupo.Key,
                               total = grupo.Sum(p => p.Quantity)
                           };
                    
        var shopByProduct = from shop in _context.Shops
                            group shop by shop.ProductId into grupo
                            select new {
                                productId = grupo.Key,
                                total = grupo.Sum(p => p.Quantity)
                            };
        
        var totalStock = from rep in repByProduct
                         join shop in shopByProduct
                         on rep.productId equals shop.productId
                         select new {
                            productId = rep.productId,
                            inStock = rep.total - shop.total
                         };
        
        List<Stock> availableProducts = new();

        foreach(var productAvailable in totalStock) {
            var product = await _context.Products.Where(
                p => p.Id == productAvailable.productId
            ).FirstOrDefaultAsync();

            availableProducts.Add(new Stock(product!, productAvailable.inStock));
        }                 

        return availableProducts;
    }
}
