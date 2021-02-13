using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BikeRide
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
        public DashBoard()
        {
            InitializeComponent();
            App._currentlySelectedId = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new Edit_Customer_information();

            win.WindowStartupLocation = this.WindowStartupLocation;


            this.Close();
            //collabsed the Window



            win.Show();
        }

        private void SubmitBikeRental(object sender, RoutedEventArgs e)
        {
            var win = new SubmitBikeRental();

            win.WindowStartupLocation = this.WindowStartupLocation;


            this.Close();
            //collabsed the Window



            win.Show();
        }

        private void Button_Click_CheckCustomerRentStatus(object sender, RoutedEventArgs e)
        {

            var win = new Check_Customer_rent_status();


            this.Close();
            //collabsed the Window



            win.Show();

        }
    }
}
