using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class Questions
    {
        public int QuestionNumber { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string AnswerChoice { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public bool Score { get; set; }
    }
}
