using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuiz.Models
{
    public class OpenQuestion : QuestionBase
    {
        private string _correctAnswer;

        public string CorrectAnswer
        {
            get { return _correctAnswer; }
            set { _correctAnswer = value; }
        }

        public OpenQuestion(string text, int points, string correctAnswer)
            : base(text, points)
        {
            _correctAnswer = correctAnswer;
        }

        public override bool CheckAnswer(string userAnswer)
        {
            return userAnswer.Equals(_correctAnswer);
        }
    }
}
