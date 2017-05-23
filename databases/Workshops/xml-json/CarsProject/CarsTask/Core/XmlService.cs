using CarsTask.Core.Interfaces;
using CarsTask.Models;
using CarsTask.Models.Interfaces;
using System.Collections.Generic;
using System.Xml;

namespace CarsTask.Core
{
    public class XmlService : IXmlService
    {

        public IQuery ParseQuery(string pathToFile, IList<IWhereClause> whereClauses)
        {
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

        private Operation GetOperation(string type)
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

        public void ExportXmlResult(IList<ICar> resultFromQuery, string outputName)
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
    }
}
