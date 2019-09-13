using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.WebApi.Attributes;

namespace TechnicalRadiation.WebApi.Controllers
{
  [Route("api/")]
    public class CategoryController : ControllerBase
    {
        private CategoryService _categoryService;

        public CategoryController(IMapper mapper)
        {
            _categoryService = new CategoryService(mapper);
        }

        // GET /api/categories
        [HttpGet]
        [Route("categories")]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        // GET /api/categories/5
        [HttpGet]
        [Route("categories/{id:int}", Name = "GetCategoryById")]
        public ActionResult<string> GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null) { return NotFound(); }
            return Ok(category);
        }

        [HttpPatch]
        [Route("categories/{cid:int}/newsItems/{nid:int}")]
        [AuthorizeBearer]
        public ActionResult<string> LinkNewsItemToCategoryById(int cid, int nid)
        {
            _categoryService.LinkNewsItemToCategoryById(cid, nid);
            return NoContent();
        }

        // POST /api/categories
        [Route("categories")]
        [HttpPost]
        [AuthorizeBearer]
        public IActionResult CreateCategory([FromBody] CategoryInputModel category)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            var entity = _categoryService.CreateCategory(category);
            return CreatedAtAction("GetCategoryById", new { id = entity.Id }, null);
        }

        // PUT /api/categories/5
        
        [Route("categories/{id:int}")]
        [HttpPut]
        [AuthorizeBearer]
        public IActionResult UpdateCategoryById([FromBody] CategoryInputModel category, int id)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted.");}
            _categoryService.UpdateCategoryById(category, id);
            return NoContent();
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategoryById(id);
            return NoContent();
        }
    }
}
