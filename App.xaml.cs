using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace BikeRide
    
{
    /// <summary>
    /// 
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<Customer> _customers;
        public static ObservableCollection<Bike> _bikes;
        public static List<Rental> _Rentals;
      //  public static Dictionary<int, Rental> _Map_Rentals;
        public static int _currentlySelectedId;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _customers = My_Storage.ReadXml<ObservableCollection<Customer>>("Customers.xml");
            _bikes = My_Storage.ReadXml<ObservableCollection<Bike>>("Bikes.xml");


           //_Map_Rentals = new Dictionary<int, Rental>();


            _Rentals = My_Storage.ReadXml<List<Rental>>("Rentals.xml");

       
           


        }
     
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            My_Storage.WriteXml(_customers, "Customers.xml");
            My_Storage.WriteXml(_bikes, "Bikes.xml");  
           

        }
    }
}
