using AutoMapper;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using QuestionAnswer.Models;

namespace QuestionAnswer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly BLL _bLLibrary;
        private readonly IMapper _mapper;

        public AnswerController(BLL bLLibrary, IMapper mapper)
        {
            _bLLibrary = bLLibrary;
            _mapper = mapper;
        }

        // POST api/answer
        [HttpPost]
        public IActionResult CreateAnswer(AnswerModel answerModel)
        {
            try
            {
                var answerBLL = _mapper.Map<AnswerBLL>(answerModel);
                var createdAnswer = _bLLibrary.CreateAnswer(answerBLL);
                var createdAnswerModel = _mapper.Map<AnswerModel>(createdAnswer);
                return Ok(new { message = "Answer created successfully", answer = createdAnswerModel });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while creating the response.");
            }
        }

        // GET api/answer/{id}
        [HttpGet("{id}")]
        public IActionResult GetAnswer(int id)
        {
            try
            {
                var answerBLL = _bLLibrary.GetAnswer(id);
                var answerModel = _mapper.Map<AnswerModel>(answerBLL);
                return Ok(answerModel);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while retrieving the response.");
            }
        }

        // GET api/answer
        [HttpGet]
        public IActionResult GetAllAnswers()
        {
            try
            {
                var answerBLLs = _bLLibrary.GetAllAnswers();
                var answerModels = _mapper.Map<IEnumerable<AnswerModel>>(answerBLLs);
                return Ok(answerModels);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while retrieving all responses.");
            }
        }

        // PUT api/answer/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAnswer(int id, AnswerModel answerModel)
        {
            try
            {
                if (id != answerModel.Id)
                {
                    return BadRequest();
                }

                var answerBLL = _mapper.Map<AnswerBLL>(answerModel);
                _bLLibrary.UpdateAnswer(answerBLL);

                return Ok(new { message = "Answer updated successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while updating the response.");
            }
        }

        // DELETE api/answer/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAnswer(int id)
        {
            try
            {
                _bLLibrary.DeleteAnswer(id);
                return Ok(new { message = "Answer deleted successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while deleting the response.");
            }
        }
    }
}
