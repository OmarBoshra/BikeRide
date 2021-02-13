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
using System.Xml.Linq;

namespace BikeRide
{
    /// <summary>
    /// Interaction logic for Check_Customer_rent.xaml
    /// </summary>
    public partial class Check_Customer_rent : Window
    {
        private string totalPrice;
        private string selected_Date;
        public Check_Customer_rent(Bike selectedBike ,string [] customerData , string selectedDate , string selectedTime)
        {
            InitializeComponent();

            TextBlock_CustomerName.Text = customerData[0];
            TextBlock_CustomerPhone.Text = customerData[1];
            TextBlock_CustomerEmail.Text = customerData[2];



            string filename = (customerData[3].Substring(10));

            string path = " C:/Coding/vs-apps/BikeRide/Pictures/" + filename;

            image_customer.Source = new BitmapImage(new Uri(path));


            selected_Date = selectedDate;

            string bikePricePerHrString = selectedBike.PricePerHr;

            double bikrPricePerHr = Convert.ToInt32(bikePricePerHrString.Substring(0, bikePricePerHrString.Length - 1));
           

            TextBlock_BikePrice.Text = bikePricePerHrString;
            TextBlock_BikeBrand.Text = selectedBike.Brand;
            TextBlock_BikeType.Text = selectedBike.Type;

            DateTime rent_date = (DateTime.Parse(selected_Date));



            DateTime dateFinish = DateTime.Parse(DateTime.Now.ToString("M/d/yyyy") + " " + selectedTime);

         //   DateTime resultantDate = rent_date.Add(new TimeSpan(dateFinish.Hour, dateFinish.Minute,0));


            if (dateFinish >= DateTime.Now)
            {

                double duration = ((DateTime.Now) - rent_date).TotalSeconds;


                textBlock_rentedDate.Text = selected_Date;

                totalPrice = (duration * (bikrPricePerHr / 3600)).ToString();

                textBlock_totalPrice.Text = totalPrice + " $";


            }
            else
            {


                textBlock_rentedDate.Text = "Time exceeded";
                textBlock_totalPrice.Text = "40$ fine";

                totalPrice = "40$";
            }


           
                    



        }

        private void ButtonClick_ConfirmPayment(object sender, RoutedEventArgs e)
        {

            var doc = XDocument.Load("Rentals.xml");

            var node = doc.Descendants("Rental").FirstOrDefault(cd => cd.Element("Date").Value == selected_Date);

            node.SetElementValue("TotalPrice", totalPrice);

            doc.Save("Rentals.xml");


            if (MessageBox.Show("Submitted successfully") == MessageBoxResult.OK)
            {
                var currentWindow = Window.GetWindow(this);

                currentWindow.Close();
            }


            
        }
    }
}
