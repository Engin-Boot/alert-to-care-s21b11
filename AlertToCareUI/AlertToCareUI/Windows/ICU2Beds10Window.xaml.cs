using AlertToCareUI.Views;
using System.Windows;

namespace AlertToCareUI.Windows
{
    /// <summary>
    /// Interaction logic for ICU2Beds10Window.xaml
    /// </summary>
    public partial class ICU2Beds10Window : Window
    {
        public ICU2Beds10Window()
        {
            InitializeComponent();
            AdmissionAndDischarge admission = new AdmissionAndDischarge("ICU002");
            Rectangular_10 rectangle = new Rectangular_10("ICU002");//ICU001
            //AlertManagerView alertManagerView = new AlertManagerView("ICU002");
        }
    }
}
