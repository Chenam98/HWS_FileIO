using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HWS_FileIO
{
    public class Car
    {

        //Fields & Properties

        private int codan;
        protected int NumberOfSeats;
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        //Constructors

        public Car()
        {

        }

        public Car(string filename)
        {
            
        }

        public Car(int numberOfSeats, string model, string brand, string color, int year)
        {
            NumberOfSeats = numberOfSeats;
            Model = model;
            Brand = brand;
            Color = color;
            Year = year;
        }

        //Methods

        public int GetCodan()
        {
            return codan;
        }

        public int GetNumberOfSeats()
        {
            return NumberOfSeats;
        }

        protected void ChangeNumberOfSeats(int numberOfSeats)
        {
            this.NumberOfSeats = numberOfSeats;
        }

        public static void SerializeACar(string fileName, Car car)
        {
            using (Stream serializestream = new FileStream(fileName, FileMode.Append))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Car));
                xml.Serialize(serializestream, car);
            }
        }
        public static void SerializeACarArray(string fileName, Car[] cars)
        {
            using (Stream serializestream = new FileStream(fileName, FileMode.Append))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Car));
                xml.Serialize(serializestream, cars);
            }   
        }

        public static Car DeserializeACar(string fileName)
        {
            using (Stream stream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Car));  
                Car dseriCar = (Car)serializer.Deserialize(stream);
                return dseriCar;
            }
        }

        public static Car[] DeserializeACarArray(string fileName)
        {
            using (Stream stream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer serializerArray = new XmlSerializer(typeof(Car[]));
                Car[] dseriCar = (Car[])serializerArray.Deserialize(stream);
                return dseriCar;
            }
        }

        public bool CarCompare(string fileName)
        {
            using (Stream stream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer compserializer = new XmlSerializer(typeof(Car));
                Car Carcompxml = (Car)compserializer.Deserialize(stream);
            }
                return true;
        }

        //Tostring()
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
