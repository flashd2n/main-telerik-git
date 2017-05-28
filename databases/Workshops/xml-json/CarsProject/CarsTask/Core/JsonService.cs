using CarsTask.Core.Interfaces;
using CarsTask.Enums;
using CarsTask.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarsTask.Core
{
    public class JsonService : IJsonService
    {
        public IList<Car> BuildCars(string pathToFile, IList<Car> result)
        {
            using (var reader = new StreamReader(pathToFile))
            {
                var json = reader.ReadToEnd();

                result = JArray.Parse(json)
                        .Select(element => new Car(
                            element["Year"].Value<int>(),
                            (Transmission)element["TransmissionType"].Value<int>(),
                            element["ManufacturerName"].Value<string>(),
                            element["Model"].Value<string>(),
                            element["Price"].Value<decimal>(),
                            new Dealer(
                                element["Dealer"]["Name"].Value<string>(),
                                element["Dealer"]["City"].Value<string>()
                                )
                            ))
                        .ToList();
            }

            return result;

        }
    }
}
