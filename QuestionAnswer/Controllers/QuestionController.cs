using AutoMapper;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using QuestionAnswer.Models;

namespace QuestionAnswer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly BLL _bLLibrary;
        private readonly IMapper _mapper;

        public QuestionController(BLL bLLibrary, IMapper mapper)
        {
            _bLLibrary = bLLibrary;
            _mapper = mapper;
        }

        // POST api/question
        [HttpPost]
        public IActionResult CreateQuestion(QuestionModel questionModel)
        {
            try
            {
                var questionBLL = _mapper.Map<QuestionBLL>(questionModel);
                var createdQuestion = _bLLibrary.CreateQuestion(questionBLL);
                var createdQuestionModel = _mapper.Map<QuestionModel>(createdQuestion);
                return Ok(new { message = "Question created successfully", question = createdQuestionModel });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while creating the response.");
            }
        }

        // GET api/question/{id}
        [HttpGet("{id}")]
        public IActionResult GetQuestion(int id)
        {
            try
            {
                var questionBLL = _bLLibrary.GetQuestion(id);
                var questionModel = _mapper.Map<QuestionModel>(questionBLL);
                return Ok(questionModel);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while retrieving the response.");
            }
        }

        // GET api/question
        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            try
            {
                var questionBLLs = _bLLibrary.GetAllQuestions();
                var questionModels = _mapper.Map<IEnumerable<QuestionModel>>(questionBLLs);
                return Ok(questionModels);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while retrieving all responses.");
            }
        }

        // PUT api/question/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateQuestion(int id, QuestionModel questionModel)
        {
            try
            {
                if (id != questionModel.Id)
                {
                    return BadRequest();
                }

                var questionBLL = _mapper.Map<QuestionBLL>(questionModel);
                _bLLibrary.UpdateQuestion(questionBLL);

                return Ok(new { message = "Question updated successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while updating the response.");
            }
        }

        // DELETE api/question/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(int id)
        {
            try
            {
                _bLLibrary.DeleteQuestion(id);
                return Ok(new { message = "Question deleted successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while deleting the response.");
            }
        }
    }
}
