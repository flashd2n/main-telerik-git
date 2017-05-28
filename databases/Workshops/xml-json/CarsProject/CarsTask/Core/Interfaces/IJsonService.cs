using CarsTask.Models;
using System.Collections.Generic;

namespace CarsTask.Core.Interfaces
{
    public interface IJsonService
    {
        IList<Car> BuildCars(string pathToFile, IList<Car> result);
    }
}
