namespace AppCalculator
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private double CalculateDelta(double a, double b, double c)
        {
            return (Math.Pow(b, 2) - (4 * a * c));
        }

        private void CalculateRadici(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EntA.Text) || string.IsNullOrWhiteSpace(EntB.Text) || string.IsNullOrWhiteSpace(EntC.Text))
            {
                LblRisultato.Text = "Coefficienti mancanti";
                LblRisultato.TextColor = Colors.DarkGoldenrod;
                return;
            }

            if (EntA.Text.Equals("0"))
            {
                LblRisultato.Text = "Coefficiente A non può essere 0";
                LblRisultato.TextColor = Colors.DarkGoldenrod;
                return;
            }

            double a = Convert.ToDouble(EntA.Text);
            double b = Convert.ToDouble(EntB.Text);
            double c = Convert.ToDouble(EntC.Text);
            double delta = CalculateDelta(a,b,c);

            if (delta > 0)
            {
                double solution1 = ((-1 * b) + Math.Sqrt(delta)) / (2 * a);
                double solution2 = ((-1 * b) - Math.Sqrt(delta)) / (2 * a);
                LblRisultato.TextColor = Colors.DarkGreen;
                LblRisultato.Text = "Risultato: " + solution1.ToString("F") + "; " + solution2.ToString("F");
            }
            else if (delta == 0)
            {
                double solution1 = (-1 * b) / (2 * a);
                LblRisultato.TextColor = Colors.DarkBlue;
                LblRisultato.Text = "Risultato: " + solution1.ToString("F");
            }
            else
            {
                LblRisultato.TextColor = Colors.DarkRed;
                LblRisultato.Text = "Risultato: Impossibile";
            }
            SemanticScreenReader.Announce(LblRisultato.Text);
        }
    }

}
