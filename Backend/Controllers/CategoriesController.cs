using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Models.Interfaces;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryrepository;

        public CategoriesController(ICategoryRepository categoryrepository)
        {
            this.categoryrepository = categoryrepository;
        }
        //private readonly ProductContext _context;

        //public CategoriesController(ProductContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            return Ok(await categoryrepository.GetCategories ());
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            try
            {
                var result = await categoryrepository.GetCategory(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> PutCategory(int id, Category category)
        {
            try
            {
                if (id != category.CategoryId)
                    return BadRequest("Employee ID mismatch");

                var employeeToUpdate = await categoryrepository.GetCategory(id);

                if (employeeToUpdate == null)
                    return NotFound($"Employee with Id = {id} not found");

                return await categoryrepository.EditCategory(category);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            try
            {
                if (category == null)
                    return BadRequest();

                var createdCategory = await categoryrepository.AddCategory(category);

                return CreatedAtAction(nameof(GetCategory),
                    new { id = createdCategory.CategoryId }, createdCategory);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            try
            {
                var categoryToDelete = await categoryrepository.GetCategory(id);

                if (categoryToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await categoryrepository.delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        //private bool CategoryExists(int id)
        //{
        //    return categoryrepository.Categories.Any(e => e.CategoryId == id);
        //}
    }
}
