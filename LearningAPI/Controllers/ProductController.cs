using LearningAPI.Data;
using LearningAPI.Models.Domain;
using LearningAPI.Models.DTO;
using LearningAPI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningAPI.Controllers
{
    [Route("/api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context) 
        { 
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts(string? name)
        {
            try
            {
                var products = await _context.Products.Include(x => x.Category).ToListAsync();
                if (!string.IsNullOrEmpty(name))
                {
                    products = await _context.Products.Where(x => x.Name.Contains(name)).ToListAsync();
                }
                var productDtos = products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Image = p.Image,
                    Status = p.Status,
                    Description = p.Description,
                    CategoryName = p.Category != null ? p.Category.Name : "N/A"
                }).ToList();

                if (productDtos == null || !productDtos.Any())
                {
                    return NotFound("No products found.");
                }

                return Ok(productDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var product = _context.Products.Find(id);
            if(product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Save(ProductModel model) 
        {
            try
            {
                Product product = new Product
                {
                    Name = model.Name,
                    Price = model.Price,
                    Image = model.image,
                    Status = model.Status,
                    Description = model.Description,
                    CategoryId = model.CategoryId,
                };
                _context.Products.Add(product); 
                _context.SaveChanges();
                return Ok(product);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);  
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductModel model)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                product.Name = model.Name;
                product.Price = model.Price;
                product.Image = model.image;
                product.Status = model.Status;
                product.Description = model.Description;
                product.CategoryId = model.CategoryId;
                _context.SaveChanges();
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var product = _context.Products.Find(id);
            if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
