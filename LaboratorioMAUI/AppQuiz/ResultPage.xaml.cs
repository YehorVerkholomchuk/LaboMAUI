namespace AppQuiz;

public partial class ResultPage : ContentPage
{
	private int _score;
	private int _bestScore;
	public ResultPage(int score, int bestScore)
	{
		InitializeComponent();
		_score = score;
		_bestScore = bestScore;
		ScoreLabel.Text = _score.ToString();
        BestScoreLabel.Text = "Miglior Punteggio: " + _bestScore.ToString();
    }

    private async void OnReplayClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}