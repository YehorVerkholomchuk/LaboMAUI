namespace AppQuiz;

public partial class ResultPage : ContentPage
{
	private int _score;
    private string scorePath;
    private string content;
    private string bestName;
    public ResultPage(int score)
	{
		InitializeComponent();
		_score = score;
        SaveBest(_score);
		ScoreLabel.Text = _score.ToString();
        BestScoreLabel.Text = "BEST: " + LoadBest();
    }

    private async void OnReplayClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            await DisplayAlert("Errore", "Inserisci un nome!", "OK");
            return;
        }

        SaveBest(_score);
        await Navigation.PushAsync(new MainPage());
    }

    private void SaveBest(int score)
    {
        scorePath = Path.Combine(FileSystem.AppDataDirectory, "bestscore.txt");
        int bestNew = 0;
        string? data = LoadBest();

        if (data != null)
        {
            bestName = NameEntry.Text;
            bestNew = int.Parse(data.Split(';')[1]);
        }

        if (score >= bestNew)
        {
            try
            {
                content = bestName + ";" + score.ToString() + ";" + DateTime.Now.ToString("d");
                File.WriteAllText(scorePath, content);
                BestScoreLabel.Text = "BEST: " + content;
            }
            catch (Exception ex)
            {
                DisplayAlert("Errore", "Impossibile salvare: " + ex.Message, "OK");
            }
        }
    }

    private string? LoadBest()
    {
        if (!File.Exists(scorePath))
        {
            content = "?;0;?";
            File.WriteAllText(scorePath, content);
        }

        try
        {
            content = File.ReadAllText(scorePath);
            int bestNew;
            DateTime dateNew;

            if (int.TryParse(content.Split(';')[1], out bestNew) && DateTime.TryParse(content.Split(';')[2], out dateNew))
            {
                return content;
            }
            else
            {
                DisplayAlert("Errore", "Valore non valido nel file", "OK");
                return null;
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Errore", "Lettura fallita" + ex.Message, "OK");
            return null;
        }
    }
}