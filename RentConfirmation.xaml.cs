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
    /// Interaction logic for RentConfirmation.xaml
    /// </summary>
    public partial class RentConfirmation : Window
    {


        private int customerId;
        private int bike_Id;
        private double bikrPricePerHr;
        private List<Bike> bikes_ToOrder;
        private double total_Sum = 0;

        public RentConfirmation(List<Bike>  bikesToOrder, string[] customerData , double totalSum)
        {
            InitializeComponent();

            total_Sum = totalSum;

            bikes_ToOrder = bikesToOrder;

            TextBlock_CustomerName.Text = customerData[1];
            TextBlock_CustomerPhone.Text = customerData[2];
            TextBlock_CustomerEmail.Text = customerData[3];

            string filename = (customerData[4].Substring(10));

            string path = " C:/Coding/vs-apps/BikeRide/Pictures/" + filename;

            image_customer.Source = new BitmapImage(new Uri(path));

            customerId = Convert.ToInt32(customerData[0]);


            Lbx_Bikes.ItemsSource = bikes_ToOrder;


        }

            public RentConfirmation(Bike selectedBike, string[] customerData)
        {
            InitializeComponent();



            TextBlock_BikePrice.Text = selectedBike.PricePerHr;
            TextBlock_BikeBrand.Text = selectedBike.Brand;
            TextBlock_BikeType.Text = selectedBike.Type;



            TextBlock_CustomerName.Text = customerData[1];
            TextBlock_CustomerPhone.Text = customerData[2];
            TextBlock_CustomerEmail.Text = customerData[3];



            string filename = (customerData[4].Substring(10));

            string path = " C:/Coding/vs-apps/BikeRide/Pictures/" + filename;

            image_customer.Source = new BitmapImage(new Uri(path));



            customerId = Convert.ToInt32(customerData[0]);

            bike_Id = selectedBike.Id;


            string bikePricePerHrString = TextBlock_BikePrice.Text;

            bikrPricePerHr = Convert.ToInt32(bikePricePerHrString.Substring(0, bikePricePerHrString.Length - 1));




        }

        private void ButtonClick_ConfirmPayment(object sender, RoutedEventArgs e)
        {



            if (cbx_rentTime.Text.Equals("00:00 AM"))
            {

                MessageBox.Show("Please add lend duration");

            }
            else if (!Lbx_Bikes.HasItems)
            {



                var dateNow = DateTime.Now.ToString();

                Console.WriteLine(DateTime.Now.ToString());
                /*      DateTime startdate = (DateTime.Parse("2/7/2021 3:57:53 AM"));

                        var interval = ((DateTime.Now) - startdate).TotalSeconds;
                        Console.WriteLine(interval);*/

                var doc = XDocument.Load("Rentals.xml");
                if (doc != null)
                {



                    doc.Root.Add(
      new XElement("Rental",
        new XElement("Date", dateNow),
        new XElement("BikeId", bike_Id),
        new XElement("CustomerId", customerId),
        new XElement("TotalPrice", textBlock_totalPrice.Text.Substring(0, textBlock_totalPrice.Text.Length-3)),
                    new XElement("Time", cbx_rentTime.Text)));

                    doc.Save("Rentals.xml");

                    App._Rentals.Add(new Rental { Date = dateNow, BikeId = bike_Id, CustomerId = customerId, TotalPrice = textBlock_totalPrice.Text.Substring(0, textBlock_totalPrice.Text.Length - 3), Time = cbx_rentTime.Text});


                    MessageBox.Show("Rent Successful");

                }
            }
            else
            {


                var dateNow = DateTime.Now.ToString();

                var doc = XDocument.Load("Rentals.xml");
                if (doc != null)
                {

                    foreach (var order in bikes_ToOrder)
                    {

                        doc.Root.Add(
    new XElement("Rental",
    new XElement("Date", dateNow),
    new XElement("BikeId", order.Id),
    new XElement("CustomerId", customerId),
    new XElement("TotalPrice", order.PricePerHr),
              new XElement("Time", cbx_rentTime.Text)));

                        doc.Save("Rentals.xml");

                        App._Rentals.Add(new Rental { Date = dateNow, BikeId = order.Id, CustomerId = customerId, TotalPrice = order.PricePerHr, Time = cbx_rentTime.Text });

                    }

                    MessageBox.Show("Rent Successful");





                }



            }
        }

        private void cbx_rentTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {

                string time = (e.AddedItems[0] as ComboBoxItem).Content as string;

                string dateFinish = DateTime.Now.ToString("M/d/yyyy") + " " + time;

                var duration = ((DateTime.Parse(dateFinish)) - (DateTime.Now)).TotalSeconds;


                if (total_Sum > 0)
                {

                    textBlock_totalPrice.Text = (duration * (total_Sum / 3600)).ToString() + " " + "$";

                }
                else
                {

                    textBlock_totalPrice.Text = (duration * (bikrPricePerHr / 3600)).ToString() + " " + "$";

                }


            }
            catch
            {


            }



        }

    }
}
