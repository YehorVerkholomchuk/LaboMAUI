using Java.Util;

namespace AppQuiz;

public partial class ResultPage : ContentPage
{
	private int _score;
    string filePath;
    string content;
    public ResultPage(int score)
	{
		InitializeComponent();
		_score = score;
        SaveBestScore(_score);
		ScoreLabel.Text = _score.ToString();
        BestScoreLabel.Text = "Miglior Punteggio: " + LoadBestScore().ToString();
    }

    private async void OnReplayClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private void SaveBest(int score)
    {
        filePath = Path.Combine(
            FileSystem.AppDataDirectory, "bestscore.txt");

        int best = LoadBest();

        if (score > best)
        {
            try
            {
                content = NameEntry.Text + " | " + score.ToString() + " | " + DateTime.Now;
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                DisplayAlert("Errore",
                    "Impossibile salvare: " + ex.Message, "OK");
            }
        }
    }

    private int LoadBest()
    {
        if (!File.Exists(filePath))
        {
            return 0;
        }

        try
        {
            content = File.ReadAllText(filePath);
            //trim content for name + score + date and overwrite
            int best;

            if (int.TryParse(content, out best))
            {
                return best;
            }
            else
            {
                DisplayAlert("Errore", "Valore non valido nel file", "OK");
                return 0;
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Errore", "Lettura fallita" + ex.Message, "OK");
            return 0;
        }
    }
}