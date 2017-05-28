using CarsTask.Models.Interfaces;
using System.Collections.Generic;

namespace CarsTask.Core.Interfaces
{
    public interface IXmlService
    {
        IQuery ParseQuery(string pathToFile, IList<IWhereClause> whereClauses);

        void ExportXmlResult(IList<ICar> resultFromQuery, string outputName);
    }
}
