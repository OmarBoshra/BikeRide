using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace BikeRide
{
    public class My_Storage
    {

        public static T ReadXml<T>(string file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));

                    return (T)xs.Deserialize(sr);

                }

            }
            catch (Exception x)
            {
              

                return default(T);

            }

        }

        public static void WriteXml<T>(T customers, string file)
        {

            try
            {

                XmlSerializer xs = new XmlSerializer(typeof(T));

                FileStream fs = new FileStream(file, FileMode.Create);

                xs.Serialize(fs, customers);

                fs.Close();

            }
            catch (Exception x)
            {

            }
        }

    }

}
