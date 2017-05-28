using CarsTask.Core.Interfaces;
using CarsTask.Models;
using CarsTask.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace CarsTask.Core
{
    public class ExpressionBuilder : IExpressionBuilder
    {
        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains");

        public Expression<Func<T, bool>> GetExpression<T>(IList<IWhereClause> filters)
        {
            if (filters.Count == 0)
            {
                return null;
            }

            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression expression = null;

            if (filters.Count == 1)
            {
                expression = GetExpression<T>(param, filters[0]);
            }
            else if (filters.Count == 2)
            {
                expression = GetExpression<T>(param, filters[0], filters[1]);
            }
            else
            {
                while (filters.Count > 0)
                {
                    var filterOne = filters[0];
                    var filterTwo = filters[1];

                    if (expression == null)
                        expression = GetExpression<T>(param, filters[0], filters[1]);
                    else
                        expression = Expression.AndAlso(expression, GetExpression<T>(param, filters[0], filters[1]));

                    filters.Remove(filterOne);
                    filters.Remove(filterTwo);

                    if (filters.Count == 1)
                    {
                        expression = Expression.AndAlso(expression, GetExpression<T>(param, filters[0]));
                        filters.RemoveAt(0);
                    }
                }
            }

            return Expression.Lambda<Func<T, bool>>(expression, param);
        }

        private Expression GetExpression<T>(ParameterExpression param, IWhereClause filter)
        {
            Expression body = param;

            if (filter.Property == "City" || filter.Property == "Name")
            {
                body = Expression.PropertyOrField(body, "Dealer");
                body = Expression.PropertyOrField(body, filter.Property);
            }
            else
            {
                body = Expression.Property(param, filter.Property);
            }
            
            ConstantExpression constant = GetExpressionConstant(filter.Property, filter.Value);
            
            switch (filter.Type)
            {
                case Operation.Equals:
                    return Expression.Equal(body, constant);

                case Operation.GreaterThan:
                    return Expression.GreaterThan(body, constant);

                case Operation.LessThan:
                    return Expression.LessThan(body, constant);

                case Operation.Contains:
                    return Expression.Call(body, containsMethod, constant);

            }

            return null;
        }

        private ConstantExpression GetExpressionConstant(string property, string value)
        {
            if (property == "Id" || property == "Year")
            {
                var result = 0;
                int.TryParse(value, out result);
                return Expression.Constant(result);
            }
            else if (property == "Price")
            {
                decimal result = 0;
                decimal.TryParse(value, out result);
                return Expression.Constant(result);
            }
            else
            {
                return Expression.Constant(value);
            }
        }

        private BinaryExpression GetExpression<T>(ParameterExpression param, IWhereClause filter1, IWhereClause filter2)
        {
            Expression expressionOne = GetExpression<T>(param, filter1);
            Expression expressionTwo = GetExpression<T>(param, filter2);

            return Expression.AndAlso(expressionOne, expressionTwo);
        }
    }
}
