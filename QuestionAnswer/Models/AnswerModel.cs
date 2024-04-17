namespace QuestionAnswer.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string? Options_Answers { get; set; }
        public bool IsCorrect { get; set; }
    }
}
