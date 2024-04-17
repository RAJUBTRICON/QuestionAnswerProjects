using AutoMapper;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using QuestionAnswer.Models;

namespace QuestionAnswer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BLL _bLLibrary;
        private readonly IMapper _mapper;

        public CategoryController(BLL bLLibrary, IMapper mapper)
        {
            _bLLibrary = bLLibrary;
            _mapper = mapper;
        }

        // POST api/category
        [HttpPost]
        public IActionResult CreateCategory(CategoryModel categoryModel)
        {
            try
            {
                var categoryBLL = _mapper.Map<CategoryBLL>(categoryModel);
                var createdCategory = _bLLibrary.CreateCategory(categoryBLL);
                var createdCategoryModel = _mapper.Map<CategoryModel>(createdCategory);
                return Ok(new { message = "Category created successfully", category = createdCategoryModel });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while creating the response.");
            }
        }

        // GET api/category/{id}
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            try
            {
                var categoryBLL = _bLLibrary.GetCategory(id);
                var categoryModel = _mapper.Map<CategoryModel>(categoryBLL);
                return Ok(categoryModel);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while retrieving the response.");
            }
        }

        // GET api/category
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                var categoryBLLs = _bLLibrary.GetAllCategories();
                var categoryModels = _mapper.Map<IEnumerable<CategoryModel>>(categoryBLLs);
                return Ok(categoryModels);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while retrieving all responses.");
            }
        }

        // PUT api/category/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, CategoryModel categoryModel)
        {
            try
            {
                if (id != categoryModel.Id)
                {
                    return BadRequest();
                }

                var categoryBLL = _mapper.Map<CategoryBLL>(categoryModel);
                _bLLibrary.UpdateCategory(categoryBLL);

                return Ok(new { message = "Category updated successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while updating the response.");
            }
        }

        // DELETE api/category/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _bLLibrary.DeleteCategory(id);
                return Ok(new { message = "Category deleted successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while deleting the response.");
            }
        }

        [HttpGet("CategoryWiseQuestions")]
        public IActionResult GetCategoryWiseQuestions()
        {
            try
            {
                var categoryquestions = _bLLibrary.GetCategoriesWithQuestionsAndAnswers(); // Call the BLL method
                var categoryDTOs = _mapper.Map<IEnumerable<CategoryDTO>>(categoryquestions); // Map to DTO

                return Ok(categoryDTOs); // Return mapped response
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while retrieving responses with answers.");
            }
        }
    }
}
