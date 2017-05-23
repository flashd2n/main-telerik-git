using CarsTask.Enums;

namespace CarsTask.Models.Interfaces
{
    public interface ICar
    {
        int Id { get; }
        int Year { get; set; }
        Transmission TransmissionType { get; set; }
        string Manufacturer { get; set; }
        string Model { get; set; }
        decimal Price { get; set; }
        IDealer Dealer { get; set; }
    }
}
