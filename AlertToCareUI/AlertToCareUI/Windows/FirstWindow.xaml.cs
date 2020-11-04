using System.Collections.Generic;
using System.Windows;


namespace AlertToCareUI.Windows
{
    /// <summary>
    /// Interaction logic for FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        public FirstWindow()
        {
            InitializeComponent();
            List<string> LayoutTypes = new List<string> { "L-Shaped", "Rectangular" };
            LayoutSelector.ItemsSource = LayoutTypes;
            List<string> NoOfBeds = new List<string> { "10", "12" };
            NoOfBedSelector.ItemsSource = NoOfBeds;
        }
        private void SelectLayout_Click(object sender, RoutedEventArgs e)
        { 
            if (LayoutSelector.SelectedItem.ToString() == "L-Shaped")
            {
                LayoutOneandOpenNextWindow();
            }
            else
            {

                LayoutTwoandOpenNextWindow();
            }
        }
        private void LayoutOneandOpenNextWindow()
        {
            if (NoOfBedSelector.SelectedItem.ToString() == "10")
            {
                //string ICUID = "ICU004";
                ICU1Beds10Window obj1 = new ICU1Beds10Window();
                obj1.Show();
                this.Close();
            }
            else
            {
                //string ICUID = "ICU003";
                ICU1Beds12Window obj2 = new ICU1Beds12Window();
                obj2.Show();
                this.Close();
            }
        }
        private void LayoutTwoandOpenNextWindow()
        {
            if (NoOfBedSelector.SelectedItem.ToString() == "10")
            {
                //string ICUID = "ICU002";
                ICU2Beds10Window obj3 = new ICU2Beds10Window();
                obj3.Show();
                this.Close();
            }
            else
            {
                //string ICUID = "ICU001";
                ICU2Beds12Window obj4 = new ICU2Beds12Window();
                obj4.Show();
                this.Close();
            }
        }
    }
}
