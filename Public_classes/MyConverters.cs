using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BikeRide.Public_classes
{
    public class Brand2ImagePath : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
       

          //  int bikeId = App._Map_Rentals[customerId].BikeId;
          //  string brand = App._bikes[bikeId].Brand;

            

            return $"/Pictures/Bikes/{value}.png";


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    public class String2Phone : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {


            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string phone ="";

            if (phone.Equals("EG"))
            {
                phone = "+20";
            }
            else if (phone.Equals("DE"))
            {
                phone = "+49";

            }
            else if (phone.Equals("CH"))
            {

                phone = "+86";
            }
            else if (phone.Equals("US"))
            {
                phone = "+1";

            }else
            if (value is int)
            {

        
                    phone = (string)value;
            }
            else
            {
                phone = App._customers.Single(x => x.Id == App._currentlySelectedId).Phone;

            }

            return phone;
        }

    }
}
