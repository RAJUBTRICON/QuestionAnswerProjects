using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CategoryDTO
    {
        public string? Name { get; set; }

        public List<QuestionDTO> questions { get; set; }    
    }
}
