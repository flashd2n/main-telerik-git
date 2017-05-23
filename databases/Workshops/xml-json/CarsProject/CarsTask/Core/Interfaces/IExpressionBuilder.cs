using CarsTask.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarsTask.Core.Interfaces
{
    public interface IExpressionBuilder
    {
        Expression<Func<T, bool>> GetExpression<T>(IList<IWhereClause> filters);
    }
}
