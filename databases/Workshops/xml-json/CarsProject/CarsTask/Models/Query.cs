using CarsTask.Models.Interfaces;
using System.Collections.Generic;

namespace CarsTask.Models
{
    public class Query : IQuery
    {
        public Query(string outputName, string orderParameter, IList<IWhereClause> whereClauses)
        {
            this.OutputName = outputName;
            this.OrderParameter = orderParameter;
            this.WhereClauses = whereClauses;
        }

        public string OutputName { get; set; }
        public string OrderParameter { get; set; }
        public IList<IWhereClause> WhereClauses { get; set; }

    }
}
