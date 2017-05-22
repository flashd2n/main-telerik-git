using CarsTask.Enums;
using CarsTask.Models;
using CarsTask.Models.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsTask
{
    public class Startup
    {
        static void Main()
        {
            var myCars = new List<Car>();

            using (var reader = new StreamReader("../../data/data.json"))
            {
                var json = reader.ReadToEnd();

                myCars = JArray.Parse(json)
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



        }
    }
}
