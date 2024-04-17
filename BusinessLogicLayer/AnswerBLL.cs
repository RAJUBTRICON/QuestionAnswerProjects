

namespace BusinessLogicLayer
{
    public class AnswerBLL
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string? Options_Answers { get; set; }
        public bool IsCorrect { get; set; }
    }
}
