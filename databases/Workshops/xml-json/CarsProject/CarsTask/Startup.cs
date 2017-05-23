﻿using CarsTask.Enums;
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
using CarsTask.Core;
using System.ComponentModel;

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

            var expression = ExpressionBuilder.GetExpression<ICar>(query.WhereClauses).Compile();

            var resultFromQuery = myCars
                .Where(expression)
                .OrderBy(query.OrderParameter)
                .ToList();

            // parse output

            ExportXmlResult(resultFromQuery, query.OutputName);

        }

        private static void ExportXmlResult(List<ICar> resultFromQuery, string outputName)
        {
            using (var writer = XmlWriter.Create($"../../Output/{outputName}"))
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("Cars");

                writer.WriteAttributeString("xmlns", "xsi", null, @"http://www.w3.org/2001/XMLSchema-instance");
                writer.WriteAttributeString("xmlns", "xsd", null, @"http://www.w3.org/2001/XMLSchema");

                foreach (var car in resultFromQuery)
                {
                    WriteCar(writer, car);
                }

                writer.WriteEndElement();

                writer.WriteEndDocument();
            }
        }

        private static void WriteCar(XmlWriter writer, ICar car)
        {
            writer.WriteStartElement("Car");
            writer.WriteAttributeString("Manufacturer", car.Manufacturer);
            writer.WriteAttributeString("Model", car.Model);
            writer.WriteAttributeString("Year", car.Year.ToString());
            writer.WriteAttributeString("Price", car.Price.ToString());

            writer.WriteElementString("TransmissionType", car.TransmissionType.ToString());

            writer.WriteStartElement("Dealer");
            writer.WriteAttributeString("Name", car.Dealer.Name);

            writer.WriteStartElement("Cities");

            writer.WriteElementString("City", car.Dealer.City);

            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
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

                        var operation = GetOperation(type);

                        node.Read();

                        var value = node.Value;

                        whereClauses.Add(new WhereClause(key, operation, value));
                    }
                }
            }
            return new Query(outputName, orderParameter, whereClauses);
        }

        private static Operation GetOperation(string type)
        {
            switch (type)
            {
                case "Equals":
                    return Operation.Equals;
                case "GreaterThan":
                    return Operation.GreaterThan;
                case "LessThan":
                    return Operation.LessThan;
                default:
                    return Operation.Contains;
            }
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
