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
    
   

    public partial class RentDetails : Window
    {
        private int CustomerfilterStatus;// ,0 customer , phone 1, email 2
        private int BikesfilterStatus;// ,0 brand , type 1, cost 2
        DoubleAnimation da;
        private ObservableCollection<Customer> customers;
        private ObservableCollection<Bike> bikes;
        private ObservableCollection<RentedBike> rentedBikesList;

        private Boolean textChanged = false;

        private Bike selectedbike;
        private string selectedDate; 
        private string selectedTime;
        string[] customerData;


        public RentDetails()
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


            bikes = App._bikes;

            if (bikes == null)
            {
                bikes = My_Storage.ReadXml<ObservableCollection<Bike>>("backup/Bikes.xml");

                MessageBox.Show("Your Customer data file name has been edited , a backup copy was reloaded");

            }

            Lbx_Bikes.ItemsSource = bikes;


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

            textChanged = true;
            //for all the text boxes
            var filter = (sender as TextBox).Text.ToLower();

            if (customers == null)
                return;

            //defualt filter by name;

            var result = from b in customers where b.Name.ToLower().Contains(filter) select b;

            switch (CustomerfilterStatus)
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

            textChanged = false;
        }

        private void Cbx_FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string selectedText = (e.AddedItems[0] as ComboBoxItem).Content as string;

            if (selectedText.Equals("Name"))
            {
                CustomerfilterStatus = 0;


            }
            else if (selectedText.Equals("Phone number"))
                CustomerfilterStatus = 1;

            else
                CustomerfilterStatus = 2;

        }

        private void listBox_customers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (textChanged== false)
            {


                rentedBikesList = new ObservableCollection<RentedBike>();

                foreach (var rent in App._Rentals)
                {

                    if ((listBox_customers.SelectedItem as Customer).Id == rent.CustomerId)
                    {
                        string brand = App._bikes[(rent.BikeId) - 1].Brand;
                        int bikeId = App._bikes[(rent.BikeId) - 1].Id;

                        rentedBikesList.Add(new RentedBike { BikeId = bikeId, Brand = brand, Date = rent.Date, Time = rent.Time });


                    }

                }

                Lbx_rentedBikes.ItemsSource = rentedBikesList;

            }

            }
       
        private void Confirm_Bike(object sender, RoutedEventArgs e)
        {

            if (Lbx_rentedBikes.SelectedItem == null)
            {

                MessageBox.Show("Please select a Bike");

            }
            else if (!(Lbx_rentedBikes.SelectedItem as RentedBike).Date.Equals("Today"))
            {
                string[] customerData = new string [] {TextBlock_Name.Text,TextBlock_PhoneNumber.Text,TextBlock_email.Text,(listBox_customers.SelectedItem as Customer).ImagePath};

           
          

                var win = new Check_Customer_rent(selectedbike, customerData, selectedDate , selectedTime);

                win.Owner = this;
                //collabsed the Window
                win.Show();
            }

           
        }

        private void Lbx_rentedBikes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Lbx_rentedBikes.SelectedItem != null)
            {

                selectedTime = (Lbx_rentedBikes.SelectedItem as RentedBike).Time;
                selectedDate = (Lbx_rentedBikes.SelectedItem as RentedBike).Date;
                selectedbike = App._bikes[(Lbx_rentedBikes.SelectedItem as RentedBike).BikeId - 1];
            }
        }



        private void TextBox_TextChangedBikes(object sender, TextChangedEventArgs e)
        {

            textChanged = true;
            var filter = (sender as TextBox).Text.ToLower();

            if (bikes == null)
                return;

            //defualt filter by name;

            var result = from b in bikes where b.Brand.ToLower().Contains(filter) select b;

            switch (BikesfilterStatus)
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


            Lbx_Bikes.ItemsSource = result;

            textChanged = false;

        }

        private void Cbx_BikesFilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            string selectedText = (e.AddedItems[0] as ComboBoxItem).Content as string;

            if (selectedText.Equals("Brand"))
            {
                BikesfilterStatus = 0;


            }
            else if (selectedText.Equals("Type"))
                BikesfilterStatus = 1;

            else
                BikesfilterStatus = 2;

        }

        private void Button_Click_RentBike(object sender, RoutedEventArgs e)
        {


            if (listBox_customers.SelectedItem == null)
            {


                MessageBox.Show("Please select a Customer");

            }

            else
            {
                customerData = new string[] { (listBox_customers.SelectedItem as Customer).Id.ToString(), TextBlock_Name.Text, TextBlock_PhoneNumber.Text, TextBlock_email.Text, (listBox_customers.SelectedItem as Customer).ImagePath };

            

            if (Lbx_rentedBikes.SelectedItem != null && (Lbx_rentedBikes.SelectedItem as RentedBike).Date.Equals("Today"))
            {



                var win = new RentConfirmation(selectedbike, customerData);

                win.Owner = this;
                //collabsed the Window
                win.Show();


            }
            else if (rentedBikesList.Any(x => x.Date.Equals("Today")))

            {

                List<RentedBike> bikesToRent = rentedBikesList.Where(i => i.Date.Equals("Today")).ToList();

                    double totalSum = 0;
                    List<Bike> bikesToOrder = new List<Bike>();
                    foreach (var toRent in bikesToRent)
                    {
                        

                             foreach (var bike in bikes) 
                        {
                            if(bike.Id == toRent.BikeId)
                            { 


                                totalSum = totalSum + (Convert.ToInt32(bike.PricePerHr.Substring(0, bike.PricePerHr.Length - 1)));

                                bikesToOrder.Add(bike);

                            }

                        }

                         


                    }



                var win = new RentConfirmation(bikesToOrder, customerData , totalSum);

                win.Owner = this;
                //collabsed the Window
                win.Show();

            }
        }

}

        private void AddBike(object sender, RoutedEventArgs e)
        {


            if (Lbx_Bikes.SelectedItem == null)
            {

                MessageBox.Show("Please select a bike");

            }
            else if (listBox_customers.SelectedItem == null)
            {

                MessageBox.Show("Please select a customer");

            }

            else
            {

                if (rentedBikesList.Any(x => x.BikeId == (Lbx_Bikes.SelectedItem as Bike).Id))
                {
                    MessageBox.Show("Bike already added");

                }
                else
                {


                    Bike selectedobj = Lbx_Bikes.SelectedItem as Bike;

                    rentedBikesList.Add(new RentedBike { BikeId = selectedobj.Id, Brand = selectedobj.Brand, Date = "Today" });


                    Lbx_rentedBikes.Items.Refresh();
                    Lbx_rentedBikes.ScrollIntoView(Lbx_rentedBikes.Items[Lbx_rentedBikes.Items.Count - 1]);


                }

            }
           
        }

   

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

        private void createCustomer(object sender, RoutedEventArgs e)
        {

            if (TextBox_NewName.Text.Length > 0 || TextBox_NewPhoneNumber.Text.Length > 0 || Textbox_Newemail.Text.Length > 0)
            {

             

                Customer cust = new Customer { Id = 7, Name = TextBox_NewName.Text, Phone = TextBox_NewPhoneNumber.Text, Email = Textbox_Newemail.Text, ImagePath = "/Pictures/omar.png" };

                customers.Add(cust);

                listBox_customers.Items.Refresh();
                listBox_customers.ScrollIntoView(cust);

            }

        }

        private void TextBox_NewPhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox_NewPhoneNumber.MaxLength = 10;
            foreach (char ch in e.Text)
                if (!Char.IsDigit(ch))
                    e.Handled = true;
        }
    }
    }

