using AutoMapper;
using DataAccessLayer;
namespace BusinessLogicLayer
{
    public class BLL
    {
        private readonly QuestionAnswerContextDB _context;
        private readonly IMapper _mapper;
        public BLL(QuestionAnswerContextDB context)
        {
            _context = context;
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Question, QuestionBLL>().ReverseMap();
                cfg.CreateMap<Answer, AnswerBLL>().ReverseMap();
                cfg.CreateMap<Category, CategoryBLL>().ReverseMap();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        //CRUD Operations of Question

        public QuestionBLL CreateQuestion(QuestionBLL questionBLL)
        {
            var questionEntity = _mapper.Map<Question>(questionBLL);
            _context.Questions.Add(questionEntity);
            _context.SaveChanges();
            return _mapper.Map<QuestionBLL>(questionEntity);
        }

        public QuestionBLL GetQuestion(int id)
        {
            var questionEntity = _context.Questions.FirstOrDefault(r => r.Id == id);
            return _mapper.Map<QuestionBLL>(questionEntity);
        }

        public IEnumerable<QuestionBLL> GetAllQuestions()
        {
            var questionEntities = _context.Questions.ToList();
            return _mapper.Map<IEnumerable<QuestionBLL>>(questionEntities);
        }

        public void UpdateQuestion(QuestionBLL questionBLL)
        {
            var questionEntity = _mapper.Map<Question>(questionBLL);
            _context.Questions.Update(questionEntity);
            _context.SaveChanges();
        }

        public void DeleteQuestion(int id)
        {
            var questionEntity = _context.Questions.FirstOrDefault(r => r.Id == id);
            if (questionEntity != null)
            {
                _context.Questions.Remove(questionEntity);
                _context.SaveChanges();
            }
        }

        //CRUD operations on Answer
        public AnswerBLL CreateAnswer(AnswerBLL answerBLL)
        {
            var answerEntity = _mapper.Map<Answer>(answerBLL);
            _context.Answers.Add(answerEntity);
            _context.SaveChanges();
            return _mapper.Map<AnswerBLL>(answerEntity);
        }

        public AnswerBLL GetAnswer(int id)
        {
            var answerEntity = _context.Answers.FirstOrDefault(r => r.Id == id);
            return _mapper.Map<AnswerBLL>(answerEntity);
        }

        public IEnumerable<AnswerBLL> GetAllAnswers()
        {
            var answerEntities = _context.Answers.ToList();
            return _mapper.Map<IEnumerable<AnswerBLL>>(answerEntities);
        }

        public void UpdateAnswer(AnswerBLL answerBLL)
        {
            var answerEntity = _mapper.Map<Answer>(answerBLL);
            _context.Answers.Update(answerEntity);
            _context.SaveChanges();
        }

        public void DeleteAnswer(int id)
        {
            var answerEntity = _context.Answers.FirstOrDefault(r => r.Id == id);
            if (answerEntity != null)
            {
                _context.Answers.Remove(answerEntity);
                _context.SaveChanges();
            }
        }
        //CRUD operations on Category
        public CategoryBLL CreateCategory(CategoryBLL categoryBLL)
        {
            var categoryEntity = _mapper.Map<Category>(categoryBLL);
            _context.Categories.Add(categoryEntity);
            _context.SaveChanges();
            return _mapper.Map<CategoryBLL>(categoryEntity);
        }

        public CategoryBLL GetCategory(int id)
        {
            var categoryEntity = _context.Categories.FirstOrDefault(r => r.Id == id);
            return _mapper.Map<CategoryBLL>(categoryEntity);
        }

        public IEnumerable<CategoryBLL> GetAllCategories()
        {
            var categoryEntities = _context.Categories.ToList();
            return _mapper.Map<IEnumerable<CategoryBLL>>(categoryEntities);
        }

        public void UpdateCategory(CategoryBLL categoryBLL)
        {
            var categoryEntity = _mapper.Map<Category>(categoryBLL);
            _context.Categories.Update(categoryEntity);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var categoryEntity = _context.Categories.FirstOrDefault(r => r.Id == id);
            if (categoryEntity != null)
            {
                _context.Categories.Remove(categoryEntity);
                _context.SaveChanges();
            }
        }

        public IEnumerable<CategoryDTO> GetCategoriesWithQuestionsAndAnswers()
        {
            var data = from cat in _context.Categories
                       join ques in _context.Questions on cat.Id equals ques.CategoryId into quesGroup
                       select new CategoryDTO
                       {
                           Name = cat.Name,
                           questions = quesGroup.Select(q => new QuestionDTO
                           {
                               Id = q.Id,
                               QuestionText = q.QuestionText,
                               Type = q.Type,
                               CreatedBy = q.CreatedBy,
                               CreatedDate = q.CreatedDate,
                               ISEnabled = q.ISEnabled,
                               answers = _context.Answers
                                          .Where(a => a.QuestionId == q.Id)
                                          .Select(a => new AnswerDTO
                                          {
                                              QuestionId = a.QuestionId,
                                              Options_Answers = a.Options_Answers,
                                              IsCorrect = a.IsCorrect
                                          }).ToList()
                           }).ToList()
                       };
            return data;
        }



    }
}
