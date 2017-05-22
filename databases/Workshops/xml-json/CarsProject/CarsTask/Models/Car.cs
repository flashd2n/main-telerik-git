using CarsTask.Enums;
using CarsTask.Models.Interfaces;

namespace CarsTask.Models
{
    public class Car : ICar
    {
        public Car(int year, Transmission transmissionType, string manufacturerName, string model, decimal price, IDealer dealer)
        {
            this.Year = year;
            this.TransmissionType = transmissionType;
            this.ManufacturerName = manufacturerName;
            this.Model = model;
            this.Price = price;
            this.Dealer = dealer;
        }

        public int Year { get; set; }
        public Transmission TransmissionType { get; set; }
        public string ManufacturerName { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public IDealer Dealer { get; set; }



    }
}
