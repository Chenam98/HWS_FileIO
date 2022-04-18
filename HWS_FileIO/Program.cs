using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HWS_FileIO
{

    public class Program
    {
        //Q17

        //public void PrintThreeBiggestFileName(string Filename)
        //{
        //    DirectoryInfo directoryInfo = new DirectoryInfo(Filename);
        //    List<FileInfo> files = directoryInfo.GetFiles().ToList();

        //}
        static void Main(string[] args)
        {

            //----------------------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------------------

            Car myCar = new Car();
            //Serialize the file
            XmlSerializer serializer = new XmlSerializer(typeof(Car));
            using (Stream myFile = new FileStream(@"E:\StreamEXR\Car.txt", FileMode.Create))
            {
                Car c1 = new Car { Model = "Christ", Brand = "Toyota", Color = "Matt Black", Year = 2019 };

                serializer.Serialize(myFile, c1);
            }
            //Deserialize the File
            using (Stream myFile = new FileStream(@"E:\StreamEXR\Car.txt", FileMode.Open))
            {
                Car ReadCarFromXml = (Car)serializer.Deserialize(myFile);
            }
            //Changing the xml content
            using (Stream myFile = new FileStream(@"E:\StreamEXR\Car.txt", FileMode.Append))
            {
                Car c2 = new Car { Model = "Shizuru", Brand = "Hundai", Color = "White", Year = 2017 };

                serializer.Serialize(myFile, c2);
            }
            //Deserialize the changing file
            using (Stream myFile = new FileStream(@"E:\StreamEXR\Car.txt", FileMode.Open))
            {
                Car ReadCarFromXml = (Car)serializer.Deserialize(myFile);
            }

            //----------------------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------------------

            XmlSerializer arraySerializer = new XmlSerializer(typeof(Car[]));
            Car[] cars = new Car[3];
            //Serialize the file
            using (Stream carArray = new FileStream(@"E:\StreamEXR\carArray.txt", FileMode.Create))
            {
                cars[0] = new Car { Model = "A", Brand = "Lambo", Color = "green", Year = 1999 };
                cars[1] = new Car { Model = "B", Brand = "Ford", Color = "Blue", Year = 2022 };
                cars[2] = new Car { Model = "C", Brand = "Shevrolet", Color = "Light Blue", Year = 2006 };

                arraySerializer.Serialize(carArray, cars);
            }

            //Reading the File
            using (Stream carArray = new FileStream(@"E:\StreamEXR\carArray.txt", FileMode.Open))
            {
                Car ReadCarFromXml = (Car)arraySerializer.Deserialize(carArray);
            }

        }
    }
}