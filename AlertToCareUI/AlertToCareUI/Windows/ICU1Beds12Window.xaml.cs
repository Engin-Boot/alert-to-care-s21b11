using AlertToCareUI.Views;
using System.Windows;


namespace AlertToCareUI.Windows
{
    /// <summary>
    /// Interaction logic for ICU1Beds12Window.xaml
    /// </summary>
    public partial class ICU1Beds12Window : Window
    {
        public ICU1Beds12Window()
        {
            InitializeComponent();
            AdmissionAndDischarge admission = new AdmissionAndDischarge("ICU003");
            LLayout_12 rectangle = new LLayout_12("ICU003");
            //AlertManagerView alertManagerView = new AlertManagerView("ICU003");
        }
    }
}
