using AlertToCareUI.Views;
using System.Windows;


namespace AlertToCareUI.Windows
{
    /// <summary>
    /// Interaction logic for ICU1Beds10Window.xaml
    /// </summary>
    public partial class ICU1Beds10Window : Window
    {
        public ICU1Beds10Window()
        {
            
            InitializeComponent();
            AdmissionAndDischarge admission = new AdmissionAndDischarge("ICU004");//ICU001
            LLayout_10 rectangle = new LLayout_10("ICU004");//ICU001
            //AlertManagerView alertManagerView = new AlertManagerView("ICU004");

        }
    }
}
