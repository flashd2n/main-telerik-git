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
using System.Xml;
using System.Linq.Dynamic;

namespace CarsTask
{
    public class Startup
    {
        static void Main()
        {
            var jsonPath = "../../data/data.json";

            var myCars = BuildCars(jsonPath);

            var queryPath = "../../data/Query.xml";

            var query = ParseQuery(queryPath);

            // apply query

            var sofia = "Sofia";

            var result = myCars
                .Where(car => car.Id == 0);

            // parse output

        }

        private static Query ParseQuery(string pathToFile)
        {
            var whereClauses = new List<IWhereClause>();
            var outputName = "";
            var orderParameter = "";

            using (var node = XmlReader.Create(pathToFile))
            {

                while (node.Read())
                {
                    if (node.IsStartElement() && node.Name == "Query")
                    {
                        outputName = node.GetAttribute("OutputFileName");
                    }


                    if (node.IsStartElement() && node.Name == "OrderBy")
                    {
                        node.Read();
                        orderParameter = node.Value;
                    }

                    if (node.IsStartElement() && node.Name == "WhereClause")
                    {
                        var key = node.GetAttribute("PropertyName");
                        var type = node.GetAttribute("Type");

                        node.Read();

                        var value = node.Value;

                        whereClauses.Add(new WhereClause(key, type, value));
                    }
                }
            }
            return new Query(outputName, orderParameter, whereClauses);
        }

        private static List<Car> BuildCars(string pathToFile)
        {
            var result = new List<Car>();

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
