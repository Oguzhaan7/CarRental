using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Common.FilterExtensions
{
    public static class FilterData
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> data, List<List<FilterValue>> filters)
        {
            foreach (var check in filters)
            {
                if (check.Count == 0)
                    return Enumerable.Empty<T>().AsQueryable();
            }


            Expression expression = null;

            var parameter = Expression.Parameter(typeof(T), "x");

            foreach (var item in filters)
            {
                List<Expression> expressions = new List<Expression>();
                foreach (var filter in item)
                {
                    var filterColumn = Expression.Property(parameter, filter.ColumnName);

                    if (filterColumn.Type == typeof(string))
                    {
                        var filterValue = Expression.Constant(filter.Value);
                        var filterNameValue = Expression.Convert(filterValue, filterColumn.Type);
                        var filterData = GetFilterType<T>(filter, filterColumn, filterNameValue);
                        expressions.Add(filterData);
                    }
                    else if (filterColumn.Type == typeof(bool))
                    {
                        var filterValueBool = bool.Parse(filter.Value);
                        var filterColumnBool = Expression.Convert(Expression.Property(parameter, filter.ColumnName), typeof(bool));
                        var filterValue = Expression.Constant(filterValueBool);
                        var filterNameValue = Expression.Convert(filterValue, filterColumnBool.Type);
                        var filterData = GetFilterType<T>(filter, filterColumn, filterNameValue);
                        expressions.Add(filterData);
                    }
                    else if (filterColumn.Type == typeof(DateTime))
                    {
                        var filterValueBool = DateTime.Parse(filter.Value);
                        var filterColumnBool = Expression.Convert(Expression.Property(parameter, filter.ColumnName), typeof(DateTime));
                        var filterValue = Expression.Constant(filterValueBool);
                        var filterNameValue = Expression.Convert(filterValue, filterColumnBool.Type);
                        var filterData = GetFilterType<T>(filter, filterColumn, filterNameValue);
                        expressions.Add(filterData);
                    }
                    else
                    {
                        var filterValueInt = int.Parse(filter.Value);
                        var filterColumnInt = Expression.Convert(Expression.Property(parameter, filter.ColumnName), typeof(int));
                        var filterValue = Expression.Constant(filterValueInt);
                        var filterNameValue = Expression.Convert(filterValue, filterColumnInt.Type);
                        var filterData = GetFilterType<T>(filter, filterColumn, filterNameValue);
                        expressions.Add(filterData);
                    }
                }

                if (expression is null)
                {
                    expression = expressions.Select(filter => filter).Aggregate(Expression.Or);
                }
                else
                {
                    expression = Expression.And(expression, expressions.Select(filter => filter).Aggregate(Expression.Or));
                }
            }
            return data.Where(Expression.Lambda<Func<T, bool>>(expression, parameter));
        }

        private static Expression GetFilterType<T>(FilterValue filterValue, MemberExpression memberExpression, UnaryExpression unaryExpression)
        {
            var Contains = memberExpression.Type.GetMethod("Contains", new Type[] { typeof(string) });
            var StartsWith = memberExpression.Type.GetMethod("StartsWith", new Type[] { typeof(string) });
            var EndsWith = memberExpression.Type.GetMethod("EndsWith", new Type[] { typeof(string) });

            if (unaryExpression.Type == typeof(string))
            {
                switch (filterValue.FilterType)
                {
                    case FilterType.Contain:
                        return Expression.Call(memberExpression, Contains, unaryExpression);
                        break;
                    case FilterType.Equal:
                        return Expression.Equal(memberExpression, unaryExpression);
                        break;
                    case FilterType.NotEqual:
                        return Expression.NotEqual(memberExpression, unaryExpression);
                        break;
                    case FilterType.StartWith:
                        return Expression.Call(memberExpression, StartsWith, unaryExpression);
                        break;
                    case FilterType.EndWith:
                        return Expression.Call(memberExpression, EndsWith, unaryExpression);
                        break;
                }
            }
            if (unaryExpression.Type == typeof(int))
            {
                switch (filterValue.FilterType)
                {
                    case FilterType.Equal:
                        return Expression.Equal(memberExpression, unaryExpression);
                        break;
                    case FilterType.NotEqual:
                        return Expression.NotEqual(memberExpression, unaryExpression);
                        break;
                    case FilterType.GreaterThan:
                        return Expression.GreaterThan(memberExpression, unaryExpression);
                        break;
                    case FilterType.GreaterThanOrEqual:
                        return Expression.GreaterThanOrEqual(memberExpression, unaryExpression);
                        break;
                    case FilterType.LessThan:
                        return Expression.LessThan(memberExpression, unaryExpression);
                        break;
                    case FilterType.LessThanOrEqual:
                        return Expression.LessThanOrEqual(memberExpression, unaryExpression);
                        break;
                    default:
                        break;
                }
            }

            if (unaryExpression.Type == typeof(bool))
            {
                return Expression.Equal(memberExpression, unaryExpression);
            }

            if (unaryExpression.Type == typeof(DateTime))
            {
                switch (filterValue.FilterType)
                {
                    case FilterType.Equal:
                        return Expression.Equal(memberExpression, unaryExpression);
                        break;
                    case FilterType.NotEqual:
                        return Expression.NotEqual(memberExpression, unaryExpression);
                        break;
                    case FilterType.GreaterThan:
                        return Expression.GreaterThan(memberExpression, unaryExpression);
                        break;
                    case FilterType.GreaterThanOrEqual:
                        return Expression.GreaterThanOrEqual(memberExpression, unaryExpression);
                        break;
                    case FilterType.LessThan:
                        return Expression.LessThan(memberExpression, unaryExpression);
                        break;
                    case FilterType.LessThanOrEqual:
                        return Expression.LessThanOrEqual(memberExpression, unaryExpression);
                        break;
                    default:
                        break;
                }
            }

            return Expression.Call(memberExpression, Contains, unaryExpression);
        }
    }
}
