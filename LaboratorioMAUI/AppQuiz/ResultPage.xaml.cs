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
        SaveBest(_score);
		ScoreLabel.Text = _score.ToString();
        BestScoreLabel.Text = "BEST: " + LoadBest();
    }

    private async void OnReplayClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private void SaveBest(int score)
    {
        filePath = Path.Combine(FileSystem.AppDataDirectory, "bestscore.txt");
        int bestNew;
        int bestCheck;

        if (LoadBest() != null)
        {
            bestNew = int.Parse(LoadBest().Split(';')[1]);
        }
        else
        {
            bestNew = 0;    
        }

        if (score > bestNew)
        {
            try
            {
                content = NameEntry.Text + ";" + score.ToString() + ";" + DateTime.Now.ToString("d");
                File.WriteAllText(filePath, content);
                BestScoreLabel.Text = "BEST: " + LoadBest();
            }
            catch (Exception ex)
            {
                DisplayAlert("Errore", "Impossibile salvare: " + ex.Message, "OK");
            }
        }
    }

    private string? LoadBest()
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "");
            content = "User;0;" + DateTime.Now.ToString("d");
        }

        try
        {
            content = File.ReadAllText(filePath);
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