using BikeRide.Public_classes;
using Microsoft.Win32;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BikeRide
{
    /// <summary>
    /// Interaction logic for Edit_Customer_information.xaml
    /// </summary>
    public partial class Edit_Customer_information : Window
    {
        ObservableCollection<Customer> customers;
        int filterStatus;// ,0 customer , phone 1, email 2
        private string fileName;
        DoubleAnimation da;

        public Edit_Customer_information()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            da = new DoubleAnimation(20, TimeSpan.FromSeconds(0.5));


            customers = App._customers;

            if (customers == null)
            {
                customers = My_Storage.ReadXml<ObservableCollection<Customer>>("backup/Customers.xml");
                MessageBox.Show("Your Customer data file name has been edited , a backup copy was reloaded");
            }
            list_customers.ItemsSource = customers;
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

            win.WindowStartupLocation = this.WindowStartupLocation;


            this.Close();
            //collabsed the Window



            win.Show();
        }
        private void Grd_Menue_MouseEnter(object sender, MouseEventArgs e)
        {
            da.To = 150;
            Grd_Menue.BeginAnimation(Grid.WidthProperty, da);



        }



        private void Grd_Menue_MouseLeave(object sender, MouseEventArgs e)
        {
            da.To = 20;
            Grd_Menue.BeginAnimation(Grid.WidthProperty, da);
        }


        internal void Add_Customer(object sender, RoutedEventArgs e)
        {

            var cust = new Customer { Id = 7, Name = "omar ", Phone = "17083423", Email = "omar@gmail.com", ImagePath = "/Pictures/omar.png" };

            customers.Add(cust);

            list_customers.ScrollIntoView(cust);
            list_customers.SelectedItem = cust;
        }

        internal void Delete_Customer(object sender, RoutedEventArgs e)
        {
            var cust = list_customers.SelectedItem as Customer;//casts the item into its class

            if (cust == null)
            {
                MessageBox.Show("please select customer first to be deleted ", "hint");
                return;

            }
            customers.Remove(cust);
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Filter = "Image Files(*.PNG; *.JPG) | *.PNG; *.JPG";
            var result = dig.ShowDialog();

            if (result == true)
            {

                fileName = dig.FileName;



                (list_customers.SelectedItem as Customer).ImagePath = fileName;
                list_customers.Items.Refresh();
            }
        }

        private void list_customers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if(list_customers.SelectedItem != null)
            App._currentlySelectedId = (list_customers.SelectedItem as Customer).Id;
            

        }

     /*   private void textBox_PhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            textBox_PhoneNumber.MaxLength = 10;
            foreach (char ch in e.Text)
                if (!Char.IsDigit(ch))
                    e.Handled = true;
        }
     */
        private void Button_Click_RentStatus(object sender, RoutedEventArgs e)
        {

            var win = new Check_Customer_rent_status();
            win.Width = Width;
            win.Height = Height;
            win.Title = "Bike Ride";
            win.Owner = this;
            win.Show();
            Visibility = Visibility.Collapsed;

         
        }

        private void Rent_Click(object sender, RoutedEventArgs e)
        {
            var win = new RentDetails();
            win.Width = Width;
            win.Height = Height;
            win.Title = "Bike Ride";
            win.Owner = this;
            win.Show();
            Visibility = Visibility.Collapsed;
        }
    }
}
