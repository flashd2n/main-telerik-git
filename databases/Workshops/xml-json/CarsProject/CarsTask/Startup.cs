using CarsTask.Models;
using CarsTask.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using CarsTask.Core;

namespace CarsTask
{
    public class Startup
    {
        private const string pathToJson = "../../data/data.json";
        private const string pathToQuery = "../../data/Query.xml";

        static void Main()
        {
            var allCars = new List<Car>();

            var jsonService = new JsonService();

            var myCars = jsonService.BuildCars(pathToJson, allCars);

            var whereClauses = new List<IWhereClause>();

            var xmlService = new XmlService();

            var query = xmlService.ParseQuery(pathToQuery, whereClauses);

            var expressionBuilder = new ExpressionBuilder();

            var expressionTree = expressionBuilder.GetExpression<ICar>(query.WhereClauses).Compile();

            var resultFromQuery = myCars
                .Where(expressionTree)
                .OrderBy(query.OrderParameter)
                .ToList();
            
            xmlService.ExportXmlResult(resultFromQuery, query.OutputName);

        }
    }
}
