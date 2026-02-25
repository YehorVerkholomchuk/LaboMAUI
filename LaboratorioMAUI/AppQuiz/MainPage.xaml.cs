using AppQuiz.Models;

namespace AppQuiz
{
    public partial class MainPage : ContentPage
    {
        private List<QuestionBase> _questions = new List<QuestionBase>();
        private int _currentIndex = 0;
        private int _score = 0;
        public MainPage()
        {
            InitializeComponent();
            _questions.Add(new TrueFalseQuestion("Il C# è un linguaggio a oggetti?", 10, true));
            _questions.Add(new TrueFalseQuestion("Python è un linguaggio compilato?", 10, false));
            _questions.Add(new TrueFalseQuestion("Maruca te lo s*ca?", 1, true));
            _questions.Add(new TrueFalseQuestion("CPT ci sta?", 1, false));
            _questions.Add(new TrueFalseQuestion("√2 = 1.41421356236 ?", 20, false));
            _questions.Add(new TrueFalseQuestion("Malakas?", -1000, true));
            ShowQuestion();
        }
        private void ShowQuestion()
        {
            if (_currentIndex < _questions.Count)
            {
                QuestionBase current = _questions[_currentIndex];
                QuestionTextLabel.Text = current.Text;
                ScoreLabel.Text = $"Punti: {_score}";
            }
            else
            {
                ScoreLabel.Text = $"Punti: {_score}";
                QuestionTextLabel.Text = $"Fine! Punteggio finale: {_score}";
                TrueButton.IsVisible = false;
                FalseButton.IsVisible = false;
            }
        }
    
        private async void OnAnswerClicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            bool userAnswer = bool.Parse(btn.CommandParameter.ToString());

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
    }

}
