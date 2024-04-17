

namespace DataAccessLayer
{
    public class Question
    {
        public int Id {  get; set; }
        public string? QuestionText { get; set; }
        public int CategoryId { get; set; }
        public string? Type { get; set; }
        public string? CreatedBy { get; set; }
        public DateOnly CreatedDate { get; set; }   
        public bool ISEnabled { get; set; }
        //public Category? categories { get; set; }
       // public ICollection<Answer>? Answers { get; set; }    
    }
}
