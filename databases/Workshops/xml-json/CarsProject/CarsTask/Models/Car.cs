using CarsTask.Enums;
using CarsTask.Models.Interfaces;

namespace CarsTask.Models
{
    public class Car : ICar
    {
        private static int id = 0;

        public Car(int year, Transmission transmissionType, string manufacturerName, string model, decimal price, IDealer dealer)
        {
            this.Id = id;
            ++id;
            this.Year = year;
            this.TransmissionType = transmissionType;
            this.Manufacturer = manufacturerName;
            this.Model = model;
            this.Price = price;
            this.Dealer = dealer;
        }

        public int Id { get; private set; }
        public int Year { get; set; }
        public Transmission TransmissionType { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public IDealer Dealer { get; set; }
    }
}
