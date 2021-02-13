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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BikeRide.Pages.SubmittingCustomerPayment
{
    /// <summary>
    /// Interaction logic for CustomerConfirmation.xaml
    /// </summary>
    public partial class CustomerConfirmation : Page
    {
        private ObservableCollection<Customer> customers;
        private int filterStatus;// ,0 customer , phone 1, email 2
        public CustomerConfirmation()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            customers = App._customers;

            if (customers == null)
            {
                customers = My_Storage.ReadXml<ObservableCollection<Customer>>("backup/Customers.xml");
                MessageBox.Show("Your Customer data file name has been edited , a backup copy was reloaded");
            }

            list_customers.ItemsSource = customers;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //for all the text boxes
            var filter = (sender as TextBox).Text.ToLower();

            if (customers == null)
                return;

            //defualt filter by name;

            var result = from b in customers where b.Name.ToLower().Contains(filter) select b;

            switch (filterStatus)
            {
                case 0:
                    result = from b in customers where b.Name.ToString().ToLower().Contains(filter) select b;
                    break;
                case 1:
                    result = from b in customers where b.Phone.ToString().ToLower().Contains(filter) select b;
                    break;
                default:
                    result = from b in customers where b.Email.ToString().ToLower().Contains(filter) select b;
                    break;

            }


            list_customers.ItemsSource = result;
        }

        private void Back2DashBoard(object sender, RoutedEventArgs e)
        {
            var win = new DashBoard();

            var currentWindow = Window.GetWindow(this);


            currentWindow.Close();
            //collabsed the Window



            win.Show();
        }
        private void ConfirmCustomer(object sender, RoutedEventArgs e)
        {

            if (TextBlock_Name.Text.Length > 0)
            {
                this.NavigationService.Navigate(new BikeConfirmation((list_customers.SelectedItem as Customer).Id,TextBlock_Name.Text, TextBlock_PhoneNumber.Text, TextBlock_email.Text, (list_customers.SelectedItem as Customer).ImagePath));
            }
            else
                MessageBox.Show("You must choose a Customer first");


            //    this.NavigationService.Navigate(new Uri("Pages/SubmittingCustomerPayment/BikeConfirmation.xaml", UriKind.Relative));

        }
        private void Cbx_FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string selectedText = (e.AddedItems[0] as ComboBoxItem).Content as string;

            if (selectedText.Equals("Name"))
            {
                filterStatus = 0;


            }
            else if (selectedText.Equals("Phone number"))
                filterStatus = 1;

            else
                filterStatus = 2;

        }
    }
}
