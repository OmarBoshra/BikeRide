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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace BikeRide.Pages.SubmittingCustomerPayment
{
    /// <summary>
    /// Interaction logic for PaymentDetails.xaml
    /// </summary>
    public partial class PaymentDetails : Page
    {
        private int customerId;
       private int bike_Id;
        private string[] customer_Data;

        public PaymentDetails(string[] customerData,int bikeId , string bikeBrand, string bikeType, string bikePrice)
        {

            InitializeComponent();

            customerId= Convert.ToInt32(customerData[0]);
         
            bike_Id = bikeId;

            TextBlock_CustomerName.Text = customerData[1];
            TextBlock_CustomerEmail.Text = customerData[2];
            TextBlock_CustomerPhone.Text = customerData[3];

            customer_Data = customerData;

            TextBlock_BikeType.Text = bikeType;
            TextBlock_BikeBrand.Text = bikeBrand;
            TextBlock_BikePrice.Text = bikePrice;

            string filename = (customerData[4].Substring(10));

            string path = " C:/Coding/vs-apps/BikeRide/Pictures/" + filename;

            image_customer.Source = new BitmapImage(new Uri(path));



        }

        private void Back2DashBoard(object sender, RoutedEventArgs e)
        {

            Back2DashBoard();
        }
        
          private void Back2DashBoard()
        {
            var win = new DashBoard();

            var currentWindow = Window.GetWindow(this);


            currentWindow.Close();
            //collabsed the Window



            win.Show();

        }


        private void ButtonClick_Back2Bikes(object sender, RoutedEventArgs e)
        {


            this.NavigationService.Navigate(new BikeConfirmation(customer_Data));

        }


        private void ButtonClick_ConfirmRental(object sender, RoutedEventArgs e)
        {

         var dateNow =    DateTime.Now.ToString();
            
            Console.WriteLine(DateTime.Now.ToString());
            DateTime startdate = (DateTime.Parse("2/7/2021 3:57:53 AM"));

            var interval = ((DateTime.Now) - startdate).TotalSeconds;
            Console.WriteLine(interval);

            var doc = XDocument.Load("Rentals.xml");
            if (doc != null)
            {

            

                doc.Root.Add(
  new XElement("Rental",
    new XElement("Date", dateNow),
    new XElement("BikeId", bike_Id),
    new XElement("CustomerId", customerId),
    new XElement("TotalPrice", "0$")));

                    doc.Save("Rentals.xml");

                    App._Rentals.Add(new Rental { Date = dateNow, BikeId = bike_Id, CustomerId = customerId, TotalPrice = "0$" });


                    //   node.Element()

                    if (MessageBox.Show("Submitted successfully") == MessageBoxResult.OK)
                    {
                        Back2DashBoard();

                    }




                






            }



        }
    }
}
