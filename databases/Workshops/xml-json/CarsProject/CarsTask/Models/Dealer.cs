using CarsTask.Models.Interfaces;

namespace CarsTask.Models
{
    public class Dealer : IDealer
    {
        public Dealer(string name, string city)
        {
            this.Name = name;
            this.City = city;
        }

        public string Name { get; set; }
        public string City { get; set; }
    }
}
