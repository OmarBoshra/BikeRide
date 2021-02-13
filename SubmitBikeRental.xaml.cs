using BikeRide.Public_classes;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BikeRide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SubmitBikeRental : Window
    {
    
        public SubmitBikeRental()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SubmitBikeRentalFrame.Content = new Pages.SubmittingCustomerPayment.CustomerConfirmation();



        }



     


 

  

 

 
    }

}
