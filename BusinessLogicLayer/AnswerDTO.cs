namespace BusinessLogicLayer
{
    public class AnswerDTO
    {
        public int QuestionId { get; set; }
        public string? Options_Answers { get; set; }
        public bool IsCorrect { get; set; }
    }
}
