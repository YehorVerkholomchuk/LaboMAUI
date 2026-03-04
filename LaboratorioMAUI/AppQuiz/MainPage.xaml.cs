using AppQuiz.Models;

namespace AppQuiz
{
    public partial class MainPage : ContentPage
    {
        private List<QuestionBase> _questions = new List<QuestionBase>();
        private int _currentIndex = 0;
        private int _score = 0;
        private int _best;
        private string filePath = Path.Combine(
                FileSystem.AppDataDirectory, "bestscore.txt");

        public MainPage()
        {
            InitializeComponent();
            _questions.Add(new TrueFalseQuestion("Il C# è un linguaggio a oggetti?", 10, "true"));
            _questions.Add(new TrueFalseQuestion("Python è un linguaggio compilato?", 10, "false"));
            _questions.Add(new OpenQuestion("2 + 2 = ...", 5, "4"));
            ShowQuestion();
        }
        private void ShowQuestion()
        {
            if (_currentIndex < _questions.Count)
            {
                QuestionBase current = _questions[_currentIndex];
                if (current.GetType() == typeof(TrueFalseQuestion))
                {
                    OpenAnswer.IsVisible = false;
                    TrueFalseAnswer.IsVisible = true;
                }
                else if (current.GetType() == typeof(OpenQuestion))
                {
                    TrueFalseAnswer.IsVisible = false;
                    OpenAnswer.IsVisible = true;
                }
                QuestionTextLabel.Text = current.Text;
                ScoreLabel.Text = $"Punti: {_score}";
            }
            else
            {
                OnQuizFinished();
            }
        }
    
        private async void OnAnswerClicked(object sender, EventArgs e)
        {
            string userAnswer;
            var btn = (Button)sender;
            if(btn.CommandParameter.ToString().Equals("Open"))
            {
                userAnswer = QuestionTextEntry.Text;
            }
            else
            {
                userAnswer = btn.CommandParameter.ToString();
            }

            if (_questions[_currentIndex].CheckAnswer(userAnswer))
            {
                _score += _questions[_currentIndex].Points;
                await DisplayAlert("Esatto!", "Hai indovinato.", "OK");
            }
            else
            {
                await DisplayAlert("Errore!", "Riprova alla prossima.", "OK");
            }
            _currentIndex++;
            ShowQuestion();
        }

        private async void OnQuizFinished()
        {
            await Navigation.PushAsync(new ResultPage(_score));
        }
    }

}
