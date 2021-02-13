using BikeRide.Public_classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BikeRide.Pages.SubmittingCustomerPayment
{
    /// <summary>
    /// Interaction logic for BikeConfirmation.xaml
    /// </summary>
    public partial class BikeConfirmation : Page
    {
        private ObservableCollection<Bike> bikes;
        private int filterStatus;// ,0 brand , type 1, pricePerHr 2
       
      private  string[] customer_Data;


        public BikeConfirmation(string[] customerData)
        {
            InitializeComponent();
            customer_Data = customerData;


        }

        public BikeConfirmation(int CustomerId ,string textBlock_Name, string textBlock_PhoneNumber, string textBlock_email ,string imagePath)
        {
            InitializeComponent();
            customer_Data = new string [] { CustomerId.ToString(), textBlock_Name, textBlock_PhoneNumber, textBlock_email , imagePath };
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            bikes = App._bikes;

            if (bikes == null)
            {
                bikes = My_Storage.ReadXml<ObservableCollection<Bike>>("backup/Bikes.xml");

                System.Windows.MessageBox.Show("Your Customer data file name has been edited , a backup copy was reloaded");




            }

            listBox_bikes.ItemsSource = bikes;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //for all the text boxes
            var filter = (sender as System.Windows.Controls.TextBox).Text.ToLower();

            if (bikes == null)
                return;

            //defualt filter by name;

            var result = from b in bikes where b.Brand.ToLower().Contains(filter) select b;

            switch (filterStatus)
            {
                case 0:
                    result = from b in bikes where b.Brand.ToString().ToLower().Contains(filter) select b;
                    break;
                case 1:
                    result = from b in bikes where b.Type.ToString().ToLower().Contains(filter) select b;
                    break;
                default:
                    result = from b in bikes where b.PricePerHr.ToString().ToLower().Contains(filter) select b;
                    break;

            }




            listBox_bikes.ItemsSource = result;
        }

        private void Cbx_FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string selectedText = (e.AddedItems[0] as ComboBoxItem).Content as string;

            if (selectedText.Equals("Brand"))
            {
                filterStatus = 0;


            }
            else if (selectedText.Equals("Type"))
                filterStatus = 1;

            else
                filterStatus = 2;

        }

        private void Confirm_Bike(object sender, RoutedEventArgs e)
        {
            if (TextBlock_BikeBrand.Text.Length > 0)
            {
                this.NavigationService.Navigate(new PaymentDetails(customer_Data, (listBox_bikes.SelectedItem as Bike).Id, TextBlock_BikeBrand.Text, textBlock_BikeType.Text, textBlock_BikePrice.Text ));
            }else
                System.Windows.MessageBox.Show("You must choose a Bike first");


        }

        private void Back2DashBoard(object sender, RoutedEventArgs e)
        {
            var win = new DashBoard();

            var currentWindow = Window.GetWindow(this);


            currentWindow.Close();
            //collabsed the Window



            win.Show();
        }
        private void Back2Customers(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new Uri("Pages/SubmitBikeRental/CustomerConfirmation.xaml", UriKind.Relative));
        }
        

    }
}
