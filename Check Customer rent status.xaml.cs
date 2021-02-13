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
    /// Interaction logic for Check_Customer_rent_status.xaml
    /// </summary>
    
   

    public partial class Check_Customer_rent_status : Window
    {
        private int filterStatus;// ,0 customer , phone 1, email 2

        DoubleAnimation da;


        private ObservableCollection<Customer> customers;
        private ObservableCollection<RentedBike> rentedBikesList;

        private Bike selectedbike;
        private string selectedDate;
        private string selectedTime;
        public Check_Customer_rent_status()
        {
            InitializeComponent();
        }

        private void Back2DashBoard(object sender, RoutedEventArgs e)
        {
            var win = new DashBoard();

            var currentWindow = Window.GetWindow(this);


            currentWindow.Close();
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            da = new DoubleAnimation(20, TimeSpan.FromSeconds(0.5));


            customers = App._customers;

            if (customers == null)
            {
                customers = My_Storage.ReadXml<ObservableCollection<Customer>>("/bin/Debug/backup/Customers.xml");
                MessageBox.Show("Your Customer data file name has been edited , a backup copy was reloaded");
            }

            listBox_customers.ItemsSource = customers;
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


            listBox_customers.ItemsSource = result;
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

        private void listBox_customers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rentedBikesList = new ObservableCollection<RentedBike>();

            foreach (var rent in App._Rentals)
            {

                if ((listBox_customers.SelectedItem as Customer).Id == rent.CustomerId)
                {
                    string brand = App._bikes[(rent.BikeId)-1].Brand;
                   int bikeId =  App._bikes[(rent.BikeId) - 1].Id;
                  
                    rentedBikesList.Add(new RentedBike {BikeId = bikeId, Brand = brand , Date = rent.Date });


                }

            }

            Lbx_rentedBikes.ItemsSource = rentedBikesList;



            }
       
        private void Confirm_Bike(object sender, RoutedEventArgs e)
        {

            string[] customerData = new string [] {TextBlock_Name.Text,TextBlock_PhoneNumber.Text,TextBlock_email.Text,(listBox_customers.SelectedItem as Customer).ImagePath};

            if(Lbx_rentedBikes.SelectedItem == null)
            {

                MessageBox.Show("Please select a Bike");

            }else
            {

                var win = new Check_Customer_rent(selectedbike, customerData, selectedDate , selectedTime);

                win.Owner = this;
                //collabsed the Window
                win.Show();
            }

           
        }

        private void Lbx_rentedBikes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTime = (Lbx_rentedBikes.SelectedItem as RentedBike).Time;

            selectedDate = (Lbx_rentedBikes.SelectedItem as RentedBike).Date;
            selectedbike = App._bikes[(Lbx_rentedBikes.SelectedItem as RentedBike).BikeId-1];
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

        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            var win = new Edit_Customer_information();
            win.Width = Width;
            win.Height = Height;
            win.Title = "Bike Ride";
            win.Owner = this;
            win.Show();
            Visibility = Visibility.Collapsed;
        }
    }
    }

