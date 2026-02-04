namespace AppConvertitore
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            //initialize graphic components
            InitializeComponent();
        }

        private void btnConvert_Clicked(object sender, EventArgs e)
        {
            try
            {
                string valoreImporto = entConvertion.Text;
                double franchi = Convert.ToDouble(valoreImporto);
                double euro = franchi * 1.09;
                lblResult.Text = "Result: " + euro.ToString("F") + " EUR";
            }
            catch (ArgumentNullException anex)
            {
                lblResult.TextColor = Colors.Red;
                lblResult.Text = "Insert something as input";
            }
            catch (FormatException fex)
            {
                lblResult.TextColor = Colors.Red;
                lblResult.Text = "Insert a valid number";
            }
            catch (OverflowException ofex)
            {
                lblResult.TextColor = Colors.Red;
                lblResult.Text = "Overflow coso";
            }
        }

        private void btnReset_Clicked(object sender, EventArgs e)
        {
            try
            {
                entConvertion.Text = null;
                lblResult.TextColor = Colors.Black;
                lblResult.Text = "Result: ";
                entConvertion.Focus();
            }
            catch (Exception ex)
            {
                DisplayAlert("Exception", ex.Message, "Ok");
            }
        }
    }

}