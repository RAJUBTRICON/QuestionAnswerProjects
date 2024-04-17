
namespace BusinessLogicLayer
{
    public class QuestionBLL
    {
        public int Id { get; set; }
        public string? QuestionText { get; set; }
        public int CategoryId { get; set; }
        public string? Type { get; set; }
        public string? CreatedBy { get; set; }
        public DateOnly CreatedDate { get; set; }
        public bool ISEnabled { get; set; }
    }
}
