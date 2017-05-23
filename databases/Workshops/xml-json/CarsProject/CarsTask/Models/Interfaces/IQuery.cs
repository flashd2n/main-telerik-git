using System.Collections.Generic;

namespace CarsTask.Models.Interfaces
{
    public interface IQuery
    {
        string OutputName { get; set; }
        string OrderParameter { get; set; }
        IList<IWhereClause> WhereClauses { get; set; }
    }
}
