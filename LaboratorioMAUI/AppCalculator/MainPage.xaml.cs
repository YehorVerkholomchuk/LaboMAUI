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
                LblRisultato.Text = "Inserisci tutti coefficienti!";
                LblRisultato.TextColor = Colors.Orange;
                return;
            }

            if (EntA.Text.Equals("0"))
            {
                LblRisultato.Text = "Coefficiente A non può essere 0!";
                LblRisultato.TextColor = Colors.Orange;
                return;
            }

            double a = Convert.ToDouble(EntA.Text);
            double b = Convert.ToDouble(EntB.Text);
            double c = Convert.ToDouble(EntC.Text);
            double delta = CalculateDelta(a,b,c);

            if (delta > 0)
            {
                LblRisultato.TextColor = Colors.Green;
            }
            else if (delta == 0)
            {
                LblRisultato.TextColor = Colors.Blue;
            }
            else
            {
                LblRisultato.TextColor= Colors.Red;
            }

            LblRisultato.Text = "Risultato: " + a;
            SemanticScreenReader.Announce(LblRisultato.Text);
        }
    }

}
