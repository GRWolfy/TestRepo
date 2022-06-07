using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace NetCoreAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsControllers : ControllerBase {
    private static List<Products> products = new List<Products> {
        new Products {id = 1, name = "Coffee", description = "Its a coffee!", price = 9.99 },
        new Products {id = 2, name = "Milk", description = "Good for your bones!", price = 99.99 },
        new Products {id = 3, name = "Sugar", description = "Sweet!", price = 19.99 }
    };

    [HttpGet]
    public async Task<ActionResult<List<Products>>> Get() {
        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<List<Products>>> AddProduct(Products product) {
        products.Add(product);
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<Products>>> Get(int id) {
        var product = products.Find(i => i.id == id);
        if(product == null) {
            return BadRequest("Product not found.");
        }
        
        return Ok(product);
    }

    [HttpPut]
    public async Task<ActionResult<List<Products>>> UpdateProduct(Products getProduct) {
        var product = products.Find(i => i.id == getProduct.id);
        if(product == null) {
            return BadRequest("Product not found.");
        }

        product.name = getProduct.name;
        product.description = getProduct.description;
        product.price = getProduct.price;

        return Ok(products);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Products>>> Delete(int id) {
        var product = products.Find(i => i.id == id);
        if(product == null) {
            return BadRequest("Product not found.");
        }
        
        products.Remove(product);
        return Ok(product);
    }
}
