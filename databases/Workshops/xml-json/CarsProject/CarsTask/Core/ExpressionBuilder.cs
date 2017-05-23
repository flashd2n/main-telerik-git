using CarsTask.Models;
using CarsTask.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace CarsTask.Core
{
    public static class ExpressionBuilder
    {
        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains");

        public static Expression<Func<T, bool>> GetExpression<T>(IList<IWhereClause> filters)
        {
            if (filters.Count == 0)
                return null;

            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression exp = null;

            if (filters.Count == 1)
                exp = GetExpression<T>(param, filters[0]);
            else if (filters.Count == 2)
                exp = GetExpression<T>(param, filters[0], filters[1]);
            else
            {
                while (filters.Count > 0)
                {
                    var f1 = filters[0];
                    var f2 = filters[1];

                    if (exp == null)
                        exp = GetExpression<T>(param, filters[0], filters[1]);
                    else
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0], filters[1]));

                    filters.Remove(f1);
                    filters.Remove(f2);

                    if (filters.Count == 1)
                    {
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0]));
                        filters.RemoveAt(0);
                    }
                }
            }

            return Expression.Lambda<Func<T, bool>>(exp, param);
        }

        private static Expression GetExpression<T>(ParameterExpression param, IWhereClause filter)
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

        private static ConstantExpression GetExpressionConstant(string property, string value)
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

        private static BinaryExpression GetExpression<T>(ParameterExpression param, IWhereClause filter1, IWhereClause filter2)
        {
            Expression bin1 = GetExpression<T>(param, filter1);
            Expression bin2 = GetExpression<T>(param, filter2);

            return Expression.AndAlso(bin1, bin2);
        }
    }
}
