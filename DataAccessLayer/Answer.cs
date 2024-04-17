using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Answer
    {
        public int Id { get; set; } 
        public int QuestionId { get; set; }
        public string? Options_Answers {  get; set; }
        public bool IsCorrect {  get; set; }  
       // public Question? questions { get; set; }
    }
}
