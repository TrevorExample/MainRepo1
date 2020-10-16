using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class QuestionsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public QuestionsController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Questions> GetQuestions()
        {

            //return new Questions { Question = "what is your name", Answer = "man" };
            var student = new Questions { QuestionNumber = 1, Question = "what is your name", Answer = "man", Answer2 = "mark", Answer3 = " maybe", Score = false };
            var student2 = new Questions { QuestionNumber = 2, Question = "what is your address", Answer = "5400 cold springs dr", Answer2 = "1234 hot springs", Answer3 = " 654 mellow bar", Score = false };
            var student3 = new Questions { QuestionNumber = 3, Question = "what is your dogs name", Answer = "douglas", Answer2 = "mark", Answer3 = " max", Score = false };
            var student4 = new Questions { QuestionNumber = 4, Question = "what is your favorite color", Answer = "red", Answer2 = "blue", Answer3 = " orange", Score = false };
            var student5 = new Questions { QuestionNumber = 5, Question = "what is your favorite food", Answer = "spagetti", Answer2 = "pizza", Answer3 = " apples", Score = false };
            var student6 = new Questions { QuestionNumber = 6, Question = "what is your favorite shirt", Answer = "polo", Answer2 = "collar", Answer3 = " button", Score = false };
            var student7 = new Questions { QuestionNumber = 7, Question = "what is your address", Answer = "5400 cold springs dr", Answer2 = "mark", Answer3 = " maybe", Score = false };

            List<Questions> cat = new List<Questions>();
            cat.Add(student);
            cat.Add(student2); cat.Add(student3); cat.Add(student4); cat.Add(student5); cat.Add(student6); cat.Add(student7);

            return cat;

            //var rng = new Random();
            //return Enumerable.Range(1, 3).Select(index => new Questions
            //{
            //    Question = "what is your name",
            //    Answer = "man"
            //})
            //.ToArray();



        }


        //[HttpPost("users/{id}")]
        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        //[EnableCors("AllowOrigin")]
        //public Questions UpdateUser(string id, [FromBody] Questions[] user)
        public string UpdateUser(string input)
        {
            //return new ChallengeResult();

            // if ((await Task.WhenAll(manageUsersPolicy, assignRolePolicy)).Any(r => !r.Succeeded))
            //    return new ChallengeResult();
            var users = new Questions { Answer = "asdfasdf", QuestionNumber = 1, Question = "what is your name", AnswerChoice = "man"};
            string response ="asdfasdf";

            var catt = JsonConvert.SerializeObject(users);
            return catt;
            
        }


        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        //[EnableCors("AllowOrigin")]
        //public Questions UpdateUser(string id, [FromBody] Questions[] user)
        public string CheckObject(Questions input2)
        {

            var users = new Questions { Answer = "asdfasdf", QuestionNumber = 1, Question = "what is your name", AnswerChoice = "man" };
            var catt = JsonConvert.SerializeObject(users);
            return catt;

        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        //[EnableCors("AllowOrigin")]
        //public Questions UpdateUser(string id, [FromBody] Questions[] user)
        public string CheckScore(Questions[] input3)
        {
            var questionsCount = input3.Count();
            int rightAnswers = 0;

            foreach (Questions question in input3){
                if (question.Score == true) { rightAnswers++; }
            }

            double num3 = (double)rightAnswers / (double)questionsCount;
            var result = num3 * 100;

            var users = new Questions { Answer = "asdfasdf", QuestionNumber = 1, Question = "what is your name", AnswerChoice = "man" };
            var catt = JsonConvert.SerializeObject(users);
            return catt;

        }
    }


}

