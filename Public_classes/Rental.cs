using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRide
{
   public  class Rental
    {
        public string Date { get; set; }
        public int BikeId { get; set; }
        public int CustomerId { get; set; }
        public string TotalPrice { get; set; }
        public string Time { get; set; }
    }
}
