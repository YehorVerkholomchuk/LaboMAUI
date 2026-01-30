namespace AppConvertitore
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            //initialize graphic components
            InitializeComponent();
        }

        private void btnConverti_Clicked(object sender, EventArgs e)
        {
            string valoreImporto = entConversione.Text;
            double franchi = Convert.ToDouble(valoreImporto);
            double euro = franchi * 1.07;
            lblRisultato.Text = "Risultato: " + euro.ToString();
        }
    }

}
