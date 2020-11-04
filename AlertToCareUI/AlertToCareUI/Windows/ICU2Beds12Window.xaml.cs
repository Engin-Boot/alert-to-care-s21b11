using AlertToCareUI.Views;
using System.Windows;


namespace AlertToCareUI.Windows
{
    /// <summary>
    /// Interaction logic for ICU2Beds12Window.xaml
    /// </summary>
    public partial class ICU2Beds12Window : Window
    {
        public ICU2Beds12Window()
        {
            InitializeComponent();
            AdmissionAndDischarge admission = new AdmissionAndDischarge("ICU001");//ICU001
            Rectangular_12 rectangle = new Rectangular_12("ICU001");//ICU001
            //AlertManagerView alertManagerView = new AlertManagerView("ICU001");
        }
    }
}
