using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Common.FilterExtensions
{
    public class FilterValue
    {
        public string ColumnName { get; set; }
        public string Value { get; set; }
        public FilterType FilterType { get; set; } = FilterType.Contain;
        public FilterValue(string columnName, string value, FilterType filterType)
        {
            ColumnName = columnName;
            Value = value;
            FilterType = filterType;
        }
    }

    public enum FilterType
    {
        Contain = 1,
        Equal,
        NotEqual,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
        StartWith,
        EndWith,
    }
}
