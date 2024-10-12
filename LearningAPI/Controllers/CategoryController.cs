using LearningAPI.Data;
using LearningAPI.Models.Domain;
using LearningAPI.Models.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningAPI.Controllers
{
    [Route("/api/category")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(string? name)
        {
            var categories = _context.Categories.ToList();
            if(!string.IsNullOrEmpty(name))
            {
                categories = _context.Categories.Where(x => x.Name.Contains(name)).ToList();
            }
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        { 
            var category = _context.Categories.Find(id);
            if (category == null) { 
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Save(CategoryModel model) {
            try
            {
                Category category = new Category
                {
                    Name = model.Name,
                    Status = model.Status,
                    CreatedDate = DateTime.Now

                };
                _context.Categories.Add(category);
                _context.SaveChanges();
                return Ok(category);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoryModel model)
        {
            var cate = _context.Categories.Find(id);
            if (cate != null)
            {
                cate.Name = model.Name;
                cate.Status = model.Status;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var category = _context.Categories.Find(id);
            if (category != null) 
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return Ok("Delete successfully !");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
