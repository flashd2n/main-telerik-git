using CarsTask.Enums;

namespace CarsTask.Models.Interfaces
{
    public interface ICar
    {
        int Year { get; set; }
        Transmission TransmissionType { get; set; }
        string ManufacturerName { get; set; }
        string Model { get; set; }
        decimal Price { get; set; }
        IDealer Dealer { get; set; }
    }
}
